using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if ((facingRight == false && moveInput > 0) || (facingRight == true && moveInput < 0))
        {
            flip();
        }

        if (moveInput == 0)
        {
            anim.SetBool("isrunning", false);
        }

        else 
        {
            anim.SetBool("isrunning", true);
        }
    }

    private void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
