using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rd;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    private BoxCollider2D cold;
    [SerializeField] private LayerMask jumpcold;

    private enum PlayerMove{idle, running, jump, fall};


    // Start is called before the first frame update
    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        cold = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rd.velocity = new Vector2( rd.velocity.x,7f);
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rd.velocity = new Vector2(dirX * 10f,rd.velocity.y);
        PlayerAnimationUpdate();
    }
    public void PlayerAnimationUpdate()
    {
        PlayerMove state;
        if (dirX > 0)
        {
            state = PlayerMove.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = PlayerMove.running;
            sprite.flipX = true;
        }
        else 
        {
            state = PlayerMove.idle;
        }
        if (rd.velocity.y > 0.1f)
        {
            state = PlayerMove.jump;
        }
        else if (rd.velocity.y < -0.1f)
        {
            state = PlayerMove.fall;
        }
        
        anim.SetInteger("state", (int)state);
    }   
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(cold.bounds.center, cold.bounds.size, 0f, Vector2.down, 0.1f, jumpcold);
    }
}

