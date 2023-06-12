using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
  [SerializeField] private Image _joystickBackground;
  [SerializeField] private Image _joystick;
  [SerializeField]private Image _joystickArea;

  private Vector2 _joystickBackgroundStartPosotion;

  protected Vector2 _inputVector;

  [SerializeField]  private Color _inActiveJoystickColor;
  [SerializeField] private Color _activeJoystickColor;

  private bool _joystickIsActive = false;
    private void Start()
    {
      ClickEffect();
      _joystickBackgroundStartPosotion = _joystickBackground.rectTransform.anchoredPosition;
    }
    public void OnDrag(PointerEventData evenData)
    {
      Vector2 joystickPosition;
      if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform, evenData.position, null, out joystickPosition))
      {
        joystickPosition.x = joystickPosition.x * 2/ _joystickBackground.rectTransform.sizeDelta.x;
        joystickPosition.y = joystickPosition.y * 2/ _joystickBackground.rectTransform.sizeDelta.y;
        _inputVector = new Vector2(joystickPosition.x, joystickPosition.y);

        _inputVector = (_inputVector.magnitude >1f)?_inputVector.normalized : _inputVector;
        _joystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x *(_joystickBackground.rectTransform.sizeDelta.x/2 ), _inputVector.y * (_joystickBackground.rectTransform.sizeDelta.y/2));

      }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
      ClickEffect();
      Vector2  joystickBackroundPosition;
      if( RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickArea.rectTransform, eventData.position, null, out joystickBackroundPosition))
      {
        _joystickBackground.rectTransform.anchoredPosition = new Vector2(joystickBackroundPosition.x, joystickBackroundPosition.y); 
      }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
      _joystickBackground.rectTransform.anchoredPosition = _joystickBackgroundStartPosotion;
      ClickEffect();
      _inputVector = Vector2.zero;
      _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
    private void ClickEffect()
    {
      if(!_joystickIsActive)
      {
        _joystick.color = _activeJoystickColor;
      _joystickIsActive = true;
      }
      else
      {
        _joystick.color = _inActiveJoystickColor;
        _joystickIsActive = false;
      }
    }
}
