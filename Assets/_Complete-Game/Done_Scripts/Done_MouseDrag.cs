using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_MouseDrag : MonoBehaviour
{

    private Vector2 _vec3Offset;                  // 偏移  
    public Vector2 _ini_pos;                      //初始位置
    private Transform targetTransform;            //目标物体
    public static int width = 3;                  
    public static int height = 3;
    public float threshold = 0.2f;                //临界值

    private bool isMouseDown = false;             //鼠标是按下
    private Vector3 lastMousePosition = Vector3.zero;

    float chipWidth = 1;                          //碎片宽度
    float chipHeight = 1;                         //碎片高度

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            for(int i = 0;i<width;i++)
            {
                for(int j = 0;j<height;j++)
                {
                    if(Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - Done_CreatePic.pic[i, j].transform.position.x) <chipWidth/2
                        && Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - Done_CreatePic.pic[i, j].transform.position.y) < chipHeight/2)
                    {
                        targetTransform = Done_CreatePic.pic[i, j].transform;                      
                        _ini_pos = new Vector2(targetTransform.position.x, targetTransform.position.y);//记录碎片初始位置
                        break;
                      
                    }
                   
                }
            }        
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
            OnMyMouseUp();         
        }

        if (isMouseDown)
        {
            if (lastMousePosition != Vector3.zero)
            {            
                //将目标物体置于最上层
                targetTransform.GetComponent<SpriteRenderer>().sortingOrder = 100;
                   
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;//鼠标偏移量
               //碎片当前位置 = 碎片上一帧的位置 + 鼠标偏移量
                targetTransform.position += offset;
             
               
                
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
       
    }

   
    void OnMyMouseUp()
    {
        for(int j = 0;j<width;j++)
        {
            for(int i= 0;i<height;i++)
            {
                if(targetTransform.name == Done_CreatePic.pic[i,j].name)
                {
                    if (Mathf.Abs(targetTransform.position.x - j)  < threshold&& Mathf.Abs(targetTransform.position.y - i) < threshold)
                    {                      
                        Debug.Log("OnMyMouseUp");
                        targetTransform.position = new Vector2(j, i);  
                        Done_GameOver._trueNum++;
                        Debug.Log(Done_GameOver._trueNum);
                        Done_GameOver.Judge();
                        break;
                    }
                    else
                    {
                        targetTransform.position = _ini_pos;
                        
                    }
                }
                targetTransform.GetComponent<SpriteRenderer>().sortingOrder = 5;       
            }
        }    
    }
}
