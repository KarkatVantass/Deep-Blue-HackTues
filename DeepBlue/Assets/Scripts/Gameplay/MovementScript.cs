using UnityEngine;

public class MovementScript : MonoBehaviour {

    Rigidbody2D rb;
    public float speed = 10;
    public float jumpHeight = 2;
    public float jumpPower = 1.5f;
    bool isGrounded = true;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 5;
    }

    void FixedUpdate()
    {
        var horizontalMovement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        if((Input.GetAxis("Vertical") != 0)
            && isGrounded == true)
        {
            jump();
            isGrounded = false;
        }

        transform.Translate(horizontalMovement,0, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        CapsuleCollider2D cc = GetComponent<CapsuleCollider2D>();
        bool hit = true;
        foreach (var point in coll.contacts)
        {
            if(point.point.y < cc.transform.position.y - cc.size.y/2)
            {
                hit = false;
                break;
            }
        }
        if (hit)
        {
            isGrounded = true;
        }
    }

    void jump()
    {
        rb.AddForce(new Vector2(0,jumpHeight)*jumpPower,ForceMode2D.Impulse);
    }
}
