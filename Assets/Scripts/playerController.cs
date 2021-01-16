using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public string upKey;

    public string downKey;

    
    private Rigidbody2D rd; 
    
    private Vector2 moveDirection = new Vector2(0,1);

    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKey(upKey)) {
            rd.MovePosition(rd.position + moveDirection * moveSpeed * Time.deltaTime);     
        }

        if (Input.GetKey(downKey)) {
            rd.MovePosition(rd.position - moveDirection * moveSpeed * Time.deltaTime);     
        }

    
    }

    private void OnCollisionEnter(Collision other) {
      
        if (other.gameObject.tag == "ball") {
            Rigidbody2D ball = other.gameObject.GetComponent<Rigidbody2D>();

            Transform tBall = other.gameObject.GetComponent<Transform>();

            float relativeY = ball.position.y - rd.position.y;

            if (relativeY > 0 ) {
                ball.AddForce(new Vector2(0, relativeY * 5));
            }
            else {
                ball.AddForce(new Vector2(0, relativeY * 5));
            }

        }
    }
}
