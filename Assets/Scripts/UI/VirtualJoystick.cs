using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform lever;
    private RectTransform _rectTransform;
    [SerializeField, Range(10f, 150f)] private float leverRange;
    
    private Vector2 _inputVector;
    private bool _isInput;

    public CharacterController characterController; // Move 함수 호출시 사용

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void Update()
    {
        if (_isInput)
        {
            InputControlVector();
        }
        
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
        Debug.Log(_inputVector);

        /*if (characterController)
        {
            characterController.Move();
        }*/
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
        _isInput = false;
        _inputVector = Vector2.zero;
        lever.anchoredPosition = Vector2.zero;
    }
}