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
    public Animator anim;
    public RectTransform AAA;
    private void Start()
    {
        jc = JumpCount;
        _characterController = GetComponent<CharacterController>();
        anim = anim.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        _moveVector = Vector3.zero;
        _moveVectorRight = Vector3.zero;
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("Run",0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            JumpCount -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector = transform.forward;
            anim.SetInteger("Run",1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector = -transform.forward;
            anim.SetInteger("Run", 4);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVectorRight = -transform.right;
            anim.SetInteger("Run", 3);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVectorRight = transform.right;
            anim.SetInteger("Run", 2);
        }

    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
        _characterController.Move(_moveVectorRight * speed * Time.fixedDeltaTime);


        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);


        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }



    public void AAAAAAAA()
    {
        AAA.localPosition = new Vector3(353.04f, 0, 0);
    }


}
