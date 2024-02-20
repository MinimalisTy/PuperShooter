using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0;
    private CharacterController _characterController;
    public float gravity = 9.8f;
    public float jumpForce;
    public int JumpCount = 1, jc;
    public float speed;
    private Vector3 _moveVector, _moveVectorRight;

    private void Start()
    {
        jc = JumpCount;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveVector = Vector3.zero;
        _moveVectorRight = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount > 0)
        {
            _fallVelocity = -jumpForce;
            JumpCount -= 1;
        }
        if (Input.GetKey(KeyCode.W))
            _moveVector = transform.forward;
        if (Input.GetKey(KeyCode.S))
            _moveVector = -transform.forward;
        if (Input.GetKey(KeyCode.A))
            _moveVectorRight = -transform.right;
        if (Input.GetKey(KeyCode.D))
            _moveVectorRight = transform.right;
    }

    void FixedUpdate()
    {
        
        if (_characterController.isGrounded)
        {
            JumpCount = jc;
            //if(!Input.GetKeyDown(KeyCode.Space))
                //_fallVelocity = 0;
        }
        else
            _fallVelocity += gravity * Time.fixedDeltaTime;


        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
        _characterController.Move(_moveVectorRight * speed * Time.fixedDeltaTime);
    }
}
