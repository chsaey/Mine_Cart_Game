using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

public class Cart : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public bool isGrounded = false;
    Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        

    }
    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
        
        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (isGrounded && Input.GetButtonDown("Jump")) // If grounded AND jump button pressed, then allow the player to jump
        {
            // add a force in the up direction
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }

    }
}
