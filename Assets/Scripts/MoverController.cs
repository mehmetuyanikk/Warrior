using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverController : IPlayerController
{
    public float HorizontalAxis => Input.GetAxis("Horizontal") * Time.deltaTime;
    public float VerticalAxis => Input.GetAxis("Vertical") * Time.deltaTime;
    public float JumpAxis => Input.GetAxis("Jump");

    public void Horizontal(Transform transform, float _playerSpeed, bool _isHorizontalActive)
    {
        switch (_isHorizontalActive)
        {
            case true:
                transform.position += new Vector3(HorizontalAxis * _playerSpeed, 0);
                break;

            case false:
                _isHorizontalActive = false;
                break;
        }
    }

    public void Vertical(Transform transfrom, float _climpSpeed, bool _isVerticalActive)
    {
        switch (_isVerticalActive)
        {
            case true:
                transfrom.position += new Vector3(0, VerticalAxis * _climpSpeed);
                break;
            
            default:
                _isVerticalActive = false;
                break;
        }
    }

    public void Jump(Rigidbody2D rigidbody2D, float _jumpForce, bool _isJumpActive)
    {
        switch (_isJumpActive)
        {
            case true:
                rigidbody2D.AddForce(Vector2.up * _jumpForce * JumpAxis);
                break;

            default:
                _isJumpActive = false;
                break;
        }
    }

    public void Flip(SpriteRenderer spriteRenderer, bool _isFlipActive)
    {
        switch (_isFlipActive)
        {
            case true:
                if (HorizontalAxis < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (HorizontalAxis > 0)
                {
                    spriteRenderer.flipX = false;
                }
                break;

            default:
                _isFlipActive = false;
                break;
        }
    }

}
