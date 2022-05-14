using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    MoverController _moverController;
    [SerializeField] Transform _playerTransfrom;
    [SerializeField] SpriteRenderer _PlayerSpriteRenderer;

    [SerializeField] Rigidbody2D _playerRigidBody2D;

    [SerializeField] float _playerSpeed, _jumpForce;
    [SerializeField] bool _isHorizontalActive, _isJumpActive, _isFlipActive;
    bool _isSpaceControl;

    [SerializeField] Animator _animator;

    void Awake()
    {
        _moverController = new MoverController();
    }

    void FixedUpdate()
    {
        Walk();
        Jump();
        Flip();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isSpaceControl = true;
        }
    }

    void Walk()
    {
        _moverController.Horizontal(_playerTransfrom, _playerSpeed, _isHorizontalActive);
        _animator.SetFloat("__isWalk", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    void Jump()
    {
        if (_isSpaceControl)
        {
            _moverController.Jump(_playerRigidBody2D, _jumpForce, _isJumpActive);
            _animator.SetBool("__isJump", _isSpaceControl);
        }
        _isSpaceControl = false;
        //_animator.SetBool("__isJump", _isSpaceControl);

    }

    void Flip()
    {
        _moverController.Flip(_PlayerSpriteRenderer, _isFlipActive);
    }

    void Climb()
    {

    }

}
