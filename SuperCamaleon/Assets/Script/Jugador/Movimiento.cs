using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public float jumpForce;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw ("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
           
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
        if (hor != 0.0f || ver != 0.0f)
        {
            Vector3 dir = transform.forward * ver + transform.right * hor;

            rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }
        

    }
}
