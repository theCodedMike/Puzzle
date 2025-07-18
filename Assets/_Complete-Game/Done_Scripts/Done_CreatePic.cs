using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_CreatePic : MonoBehaviour {
    public string sprit_Path = "Sprites/Pictures";
    public Sprite[] sp_S;//所有的图片
    public int textureNum = -1;//图片序号
    public static GameObject[,] pic = new GameObject[3,3];
    public static bool isSetTruePosition = false;


    /// <summary>
    /// 加载资源，并初始化界面
    /// </summary>
    void Start () {

        sp_S = Resources.LoadAll<Sprite>(sprit_Path);
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                textureNum++;
                pic[i,j] = new GameObject("picture" + i + j);
                //给物体一个贴图
                pic[i,j].AddComponent<SpriteRenderer>().sprite = sp_S[textureNum];              
                //将碎片放置到随机的位置
                pic[i,j].GetComponent<Transform>().position = new Vector2(Random.Range(3.0f,5.5f),Random.Range(0.0f,2.5f));              
            }
        }

    }  
}
