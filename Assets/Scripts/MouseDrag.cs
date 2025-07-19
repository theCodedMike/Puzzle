using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [Header("距离阈值")]
    public float threshold = 0.2f;
    private Vector3 _initPos; // 初始位置
    private Transform _targetTrans; // 目标物体

    public const int Width = 3;
    public const int Height = 3;
    
    private Vector3 _lastMousePos = Vector3.zero; // 上一次的鼠标位置
    private float _chipWidth = 1;  // 碎片宽度
    private float _chipHeight = 1; // 碎片高度
    private Camera _mainCamera;
    

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (GameOver.gameOver)
            return;
        
        Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Vector3 picPos = CreatePic.picMatrix[i, j].transform.position;
                    if(Mathf.Abs(mousePos.x - picPos.x) < _chipWidth / 2 && Mathf.Abs(mousePos.y - picPos.y) < _chipHeight / 2)
                    {
                        _targetTrans = CreatePic.picMatrix[i, j].transform;
                        _initPos = picPos;
                        goto outer;
                    }
                }
            }

            outer: ;
        }

        if (Input.GetMouseButton(0) && _targetTrans != null)
        {
            if (_lastMousePos != Vector3.zero)
            {   
                _targetTrans.GetComponent<SpriteRenderer>().sortingOrder = 100; // 选中的碎片置于最上层
                _targetTrans.position += mousePos - _lastMousePos; // 鼠标偏移量
            }

            _lastMousePos = mousePos;
        }
        
        if (Input.GetMouseButtonUp(0) && _targetTrans != null)
        {
            _lastMousePos = Vector3.zero;
            
            MatchOrBack();
        }
    }

    
    // 匹配或回归原位
    private void MatchOrBack()
    {
        _targetTrans.GetComponent<SpriteRenderer>().sortingOrder = 5;
        Vector3 targetPos = _targetTrans.position;
        
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (_targetTrans.name == CreatePic.picMatrix[i, j].name)
                {
                    //print($"OnMyMouseUp: {targetPos}, {j}, {i}");
                    if(Mathf.Abs(targetPos.x - j) < threshold && Mathf.Abs(targetPos.y - i) < threshold)
                    {
                        _targetTrans.position = new Vector3(j, i, 0);
                        GameOver.matchNum++;
                        GameOver.Judge();
                        _targetTrans = null;
                    }
                    else
                    {
                        _targetTrans.position = _initPos;
                    }
                    
                    goto outer;
                }
            }
        }

        outer: ;
    }
}
