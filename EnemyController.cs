using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveX { get; set; } = 1;
    
    public Rigidbody2D rb;
    
    public float speed = 10;
    
    
    private float nextActionTime = 0.0f;
    public float period = 0f;

    private bool IsRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime) 
        {
            nextActionTime += period;

            if (IsRight)
            {
                rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
                moveX += 0.005f;

                Debug.Log(rb.position.x);
                
                if (rb.position.x >= 20)
                {
                    IsRight = false;
                }
            }
            else
            {
                rb.MovePosition(rb.position + Vector2.left * moveX * speed * Time.deltaTime);
                moveX -= 0.005f;

                Debug.Log(rb.position.x);
                
                if (rb.position.x <= 10)
                {
                    IsRight = true;
                }
            }
        }
    }
}
