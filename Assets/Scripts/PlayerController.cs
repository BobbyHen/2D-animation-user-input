using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = 0F;
        // Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        moveVelocity = moveInput.normalized * speed;

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Flip character sprite when going backwards
        Vector3 characterScale = transform.localScale;
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            characterScale.x = -0.75F;
            // characterScale.y = ;
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            characterScale.x = 0.75F;
            // characterScale.y = 1;
        }

        transform.localScale = characterScale;
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown("space") == true)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            Debug.Log("Space key was pressed");
        }

        if(Input.GetKeyDown("z") == true)
        {
            Debug.Log("z key was pressed");
        }
        
        else 
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
        
    }
}
