using UnityEngine;

public class CreatePic : MonoBehaviour
{
    private const string SpritePath = "Sprites/Pictures";
    private Sprite[] _sprites;
    public int textureIdx = -1;
    public static GameObject[,] picMatrix = new GameObject[3, 3];
    public static bool isSetTruePosition;


    private void Start()
    {
        _sprites = Resources.LoadAll<Sprite>(SpritePath);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                textureIdx++;
                GameObject picObj = new GameObject($"picture{i + j}");
                picObj.AddComponent<SpriteRenderer>().sprite = _sprites[textureIdx];
                picObj.GetComponent<Transform>().position = new Vector3(Random.Range(3f, 5.5f), Random.Range(0, 2.5f), 0);
                picMatrix[i, j] = picObj;
            }
        }
    }
}