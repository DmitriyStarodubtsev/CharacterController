using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpButtonHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CharacterJumpHendler _characterJumpHendler;

    public void OnPointerDown(PointerEventData evenData)
    {
        _characterJumpHendler.HandleJump();
    }
}
