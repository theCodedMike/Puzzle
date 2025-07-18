using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_GameOver : MonoBehaviour {

    public static int _trueNum;//到达正确位置的碎片的数量
    private static int _allPicNum = 9;//碎片的数量

	
    /// <summary>
    /// 结束判定
    /// </summary>
    public static void Judge()
    {
        if (_trueNum == _allPicNum)
        {
            Debug.Log("游戏结束");
        }
    }
}
