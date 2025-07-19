using UnityEngine;

public class CreatePic : MonoBehaviour
{
    private const string SpritePath = "Sprites/Pictures";
    public static GameObject[,] picMatrix = new GameObject[3, 3];


    private void Start()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(SpritePath);
        int textureIdx = 0;
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject picObj = new GameObject($"picture{textureIdx}");
                picObj.AddComponent<SpriteRenderer>().sprite = sprites[textureIdx];
                picObj.GetComponent<Transform>().position = new Vector3(Random.Range(3f, 5.5f), Random.Range(0, 2.5f), 0);
                picMatrix[i, j] = picObj;
                textureIdx++;
            }
        }
    }
}