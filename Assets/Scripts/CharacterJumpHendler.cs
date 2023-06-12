using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterMovement))]
public class CharacterJumpHendler : MonoBehaviour
{
   [Header("Jump stats")]
   [SerializeField] private float maxJumpTime;
   [SerializeField] private float maxJumpHeight;
   private float startJumpVelocity;

   [Header("Character components")]
   private CharacterMovement _characterMovement;
   private CharacterController _characterController;


    void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _characterController = GetComponent<CharacterController>();

        float maxHeightTime = maxJumpTime/2;
        _characterMovement.GravityForce = (2*maxJumpHeight) / Mathf.Pow(maxHeightTime, 2);
        startJumpVelocity = (2* maxJumpHeight)/ maxHeightTime;
    }
    public void HandleJump()
    {
        if(_characterController.isGrounded)
        {
            _characterMovement.velocityDirection.y = startJumpVelocity;
        }
    }
}
