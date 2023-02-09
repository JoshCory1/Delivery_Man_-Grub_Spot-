using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] bool trigerSlowDown = false;
    [SerializeField] bool trigerSpeedUp = false;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSeed = 15f;
    [SerializeField] float slowSpeed = 2.5f;
    [SerializeField] float boostSpeed = 30f;
    float newSpeed = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        newSpeed = moveSeed;
    }

    // Update is  called once per frame
    void Update()
    {
        speedControl();
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; 
        float moveAmount = Input.GetAxis("Vertical") * newSpeed * Time.deltaTime;
        transform.Rotate(0,0,  -steerAmount);
        transform.Translate(0,moveAmount,0);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "SpeedUp")
        {
            trigerSlowDown = false;
            trigerSpeedUp = true;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        trigerSpeedUp =false;
        trigerSlowDown = true;
        
    }
    void speedControl()
    {
        if (trigerSpeedUp)
        {
            newSpeed = boostSpeed;
        }
        if(trigerSlowDown)
        {
            newSpeed = slowSpeed;
        }
    }
   
}
