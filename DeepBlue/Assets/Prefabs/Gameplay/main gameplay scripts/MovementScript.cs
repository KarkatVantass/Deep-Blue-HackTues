using UnityEngine;
using UnityEngine.UI;


public class MovementScript : MonoBehaviour {

    Rigidbody2D rb;
    public SpriteRenderer sprite;

    public float speed = 10;
    public float totalSpeed;

    public float jumpHeight = 2;
    public float jumpPower = 1.5f;
    bool isGrounded = true;

    void Start()
    {
        totalSpeed = speed;
        rb = this.GetComponent<Rigidbody2D>();
        sprite = this.GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        var horizontalMovement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * totalSpeed;

        if (Input.GetKeyDown(KeyCode.A) && !sprite.flipX)
        {
            sprite.flipX = true;
            Debug.Log("turn left");
        }else if(Input.GetKeyDown(KeyCode.D) && sprite.flipX)
        {

            Debug.Log("turn right");
            sprite.flipX = false;
        }

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

    public void ChangeSpeed(float speedChange)
    {
        totalSpeed -= speedChange;
    }
}
