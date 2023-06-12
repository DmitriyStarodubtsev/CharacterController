using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Charracter movement stats")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    [Header("Gravity handling")]
    private float _gravityForce = 9.8f;
    public float GravityForce
    {
        set{
            if(value >= 0)
            _gravityForce = value;
        }
    }
    

    [Header("Character component")]
    private CharacterController _characterController;
    [HideInInspector] public Vector3 velocityDirection;

    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GravityHandling();
    }
    public void MoveCharacter(Vector3 moveDirection)
    {
        velocityDirection.x = moveDirection.x * _moveSpeed;
        velocityDirection.z = moveDirection.z * _moveSpeed;
        _characterController.Move(velocityDirection * Time.deltaTime);
    }
    public void RotateCharacter (Vector3 moveDirection)
    {
        
            if(Vector3.Angle(transform.forward, moveDirection)>0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.position, moveDirection, _rotateSpeed, 0);
                transform.rotation= Quaternion.LookRotation(newDirection);
            }
        
    }
    private void GravityHandling()
    {
        if(!_characterController.isGrounded)
        {
            velocityDirection.y -=_gravityForce * Time.deltaTime;
        }
        else{
            velocityDirection.y = -0.5f;
        }
    }

}
