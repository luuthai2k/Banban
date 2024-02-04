using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraInputHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public static CameraInputHandle ins;
    public  Vector2 m_playerTouchVectorOutput;
    private bool _isPlayerTouchingPanel;
    [SerializeField] private float _speedRotate = 2f;
    private int touchID;
    public float _smoothingFactor = 2;
    public bool isTargetHeading;

  
    

    private void OutputVectorValue(Vector2 outputValue)
    {
        m_playerTouchVectorOutput = outputValue;

    }

    public Vector2 PlayerJoystickOutputVector()
    {
        return m_playerTouchVectorOutput;
    }

    public void OnPointerUp(PointerEventData _onPointerUpData)
    {
        OutputVectorValue(Vector2.zero);
        _isPlayerTouchingPanel = false;

    }

    public void OnPointerDown(PointerEventData _onPointerDownData)
    {
        OnDrag(_onPointerDownData);
        _isPlayerTouchingPanel = true;
    }
    private void Update()
    {
        SetMousePostion();
        if (Input.touchCount > 0)
        {
            if (_isPlayerTouchingPanel)
            {
                if (Input.GetTouch(touchID).phase == TouchPhase.Moved) return;
                OutputVectorValue(Vector2.zero);
            }


        }

    }

    public void SetMousePostion()
    {
        if (Input.touchCount == 0)
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            touchID = 0;
        }
        if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).position.x > Input.GetTouch(1).position.x)
            {
                touchID = 0;
            }
            else
            {
                touchID = 1;
            }
        }
    }

    public void OnDrag(PointerEventData _onDragData)
    {
        Vector2 rawInput = new Vector2(_onDragData.delta.x, _onDragData.delta.y);
        OutputVectorValue(Vector2.Lerp(m_playerTouchVectorOutput, rawInput, _smoothingFactor));
    }
    public void TargetHeading(bool enabled, float timeDelay = 0)
    {
        if (isTargetHeading == enabled) return;
        isTargetHeading = enabled;
      
    }
  
}
