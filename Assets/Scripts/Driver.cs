using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 50f;
    [SerializeField] float moveSeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is  called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; 
        float moveAmount = Input.GetAxis("Vertical") * moveSeed * Time.deltaTime;
        transform.Rotate(0,0,  -steerAmount);
        transform.Translate(0,moveAmount,0);
    }
}
