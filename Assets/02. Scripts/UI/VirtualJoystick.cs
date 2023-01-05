using DM;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform lever;
    private RectTransform _rectTransform;
    [SerializeField, Range(10f, 150f)] private float leverRange;
    
    private Vector3 _inputVector;
    private bool _isInput;

    private DM.Player _player; // Move 함수 호출시 사용

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void Update()
    {
        InputControlVector(); // 변경점
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        _isInput = true;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
    }


    private void InputControlVector()
    {
        _player.PlayerMove(_inputVector);
        _player.PlayerRotate(_inputVector);
    }
    
    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - _rectTransform.anchoredPosition;
        var clampedDir = inputDir.magnitude < leverRange ? inputDir 
            : inputDir.normalized * leverRange;
        lever.anchoredPosition = clampedDir;
        _inputVector = clampedDir / leverRange;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {        
        _inputVector = Vector2.zero;
        lever.anchoredPosition = Vector2.zero;
        _isInput = false;

    }
}