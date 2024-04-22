using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // ??????
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ??????????
        float horizontalInput = Input.GetAxis("Horizontal");

        // ???????
        Vector2 movement = new Vector2(horizontalInput, 0f) * moveSpeed;

        // ?? Animator ??????
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        // ??????
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        // ??????
        if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = false; // ???????
        }
        else if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = true; // ??????
        }
    }
}
