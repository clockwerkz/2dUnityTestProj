using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

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
    }
}
