using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class BallIniti : MonoBehaviour
{

    private System.Random ran = new System.Random();

    [SerializeField]
    private Rigidbody2D rd;
    public int InitForce = 0;

    protected int x;
    protected int y;

    [SerializeField]
    private int sleepTime = 5;

    public int borderForce; 

    public TMP_Text P1Score;
    public TMP_Text P2Score;

    // Whenever ball is instantiated.
    void OnEnable() {
        x = ran.Next(- 2, 2);
        y = ran.Next(- 2, 2);
        while (x == 0 || y == 0) {
            x = ran.Next(-2, 2);
            y = ran.Next(-2, 2);
        }
        rd.AddForce(new Vector2(x*InitForce, y*InitForce));
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "P2Goal") {
            P1Score.SetText(int.Parse(P1Score.text) + 1 + "");
        }
        else {
            P2Score.SetText(int.Parse(P2Score.text) + 1 + "");

        }
     StartCoroutine(Sleeping());

        
    }

    IEnumerator Sleeping() {
        

        
        
        Debug.Log("wait");

        yield return new WaitForSeconds(sleepTime);

        gameObject.SetActive(false);

        gameObject.transform.SetPositionAndRotation(new Vector3(0,0,0), new Quaternion());
        Debug.Log("wait2");
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision other) {

        string borderTag = other.gameObject.tag; 
        if (borderTag == "Top") {

            rd.AddForce(new Vector2(0, -1 * borderForce));

        }

        else if (borderTag == "Bottom") {

            rd.AddForce(new Vector2(0, borderForce));
        }   
    }
}
