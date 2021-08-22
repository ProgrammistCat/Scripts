using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 20;


    private bool IsJump = true;
    private bool IsJumpSecond = true;
    
    //точность до милисекунды
    private float nextActionTime = 0.0f;
    public float period = 0f;

    public int JumpForce = 5000;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space) && (IsJump || IsJumpSecond))
        {
            rb.AddForce(Vector2.up * JumpForce);

            if (IsJump)
            {
                IsJump = false;
            }
            else
            {
                IsJumpSecond = false;
            }
        }
        
        if (Time.time > nextActionTime) 
        {
            nextActionTime += period;
            
            IsJump = true;
            IsJumpSecond = true;
        }
    }
}
