using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce = 20;
    public Transform feet;
    public LayerMask groundLayer;
    public Transform wallGrab;

    private Rigidbody2D _rigidbody2d;
    private float _mx;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _mx = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(_mx * moveSpeed, _rigidbody2d.velocity.y);
        _rigidbody2d.velocity = movement;
        if (Input.GetButtonDown("Jump") && (IsGrounded() || IsWallGrabbing()))
        {
            Jump();
        }
        IsWallGrabbing();
    }

    void Jump()
    {
        Vector2 movement = new Vector2(_rigidbody2d.velocity.x, jumpForce);
        _rigidbody2d.velocity = movement;
    }

    bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.2f, groundLayer);
        return groundCheck != null;
    }

    bool IsWallGrabbing()
    {
        Collider2D wallCheck = Physics2D.OverlapCircle(wallGrab.position, 0.2f, groundLayer);
        return wallCheck != null && Input.GetAxisRaw("Horizontal") > 0;
    }
}
