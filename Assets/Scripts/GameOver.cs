using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static int matchNum;
    public const int allPicNum = 9;

    public static bool gameOver => matchNum == allPicNum;
    
    public static void Judge()
    {
        if (matchNum == allPicNum)
        {
            print("游戏结束");
        }
    }
}
