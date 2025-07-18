using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector2 _vec3Offset; // 鼠标与碎片的偏移量
    private Vector2 _initPos; // 初始位置
    private Transform _targetTrans; // 目标物体

    public const int Width = 3;
    public const int Height = 3;

    private bool _isMouseDown;
    private Vector3 _lastMousePos = Vector3.zero; // 上一次的鼠标位置
    private float _chipWidth = 1;  // 碎片宽度
    private float _chipHeight = 1; // 碎片高度

    private Camera _mainCamera;

    private bool _clickSelect; // 点击选中某个碎片

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            _isMouseDown = true;
            for (int i = 0; i < Height && _clickSelect == false; i++)
            {
                for (int j = 0; j < Width && _clickSelect == false; j++)
                {
                    Vector3 picPos = CreatePic.picMatrix[i, j].transform.position;
                    if(Mathf.Abs(mousePos.x - picPos.x) < _chipWidth / 2 && Mathf.Abs(mousePos.y - picPos.y) < _chipHeight / 2)
                    {
                        _targetTrans = CreatePic.picMatrix[i, j].transform;
                        _initPos = picPos;
                        _clickSelect = true;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isMouseDown = false;
            _lastMousePos = Vector3.zero;
            _clickSelect = false;
        }

        if (_isMouseDown)
        {
            if (_lastMousePos != Vector3.zero)
            {   
                _targetTrans.GetComponent<SpriteRenderer>().sortingOrder = 100; // 选中的碎片置于最上层
                _targetTrans.position += mousePos - _lastMousePos; // 鼠标偏移量
            }

            _lastMousePos = mousePos;
        }
    }
}
