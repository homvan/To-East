//这是一段拖动物体的代码，比较简洁明了，对了解unity3d脚本概念有些帮助！在此加上注释分享！  
var mouseOverColor = Color.blue;//声明变量为blue
private var originalColor : Color;//声明变量存储本来颜色  
private var player: GameObject;
public var gamestate: int;





var curScreenSpace;
var curPosition;
function Start () {  
    originalColor = renderer.sharedMaterial.color;//开始时得到物体本来着色  
    if (player == null){
    	player = GameObject.FindWithTag("char");
    }
    
    
}  

function OnMouseEnter () {  
        renderer.material.color = mouseOverColor;//当鼠标滑过时改变物体颜色为蓝色
    }  
  
    function OnMouseExit () {  
        renderer.material.color = originalColor;//当鼠标滑出时恢复物体本来颜色  
    }  
  
    function OnMouseDown () {  
        
        var screenSpace = Camera.main.WorldToScreenPoint(transform.position);//三维物体坐标转屏幕坐标  
        //将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离  
        var offset = transform.position - Camera.main.ScreenToWorldPoint(Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));  
        print("down");  
        //obj = 
        //clone = Instantiate();
        while (Input.GetMouseButton(0))  
        {  
            //print("button0");  
            
            curScreenSpace = Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);  
            curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset; 
            
            transform.position = curPosition;  
            yield;//这个很重要，循环执行  
        }  

    
    } 
