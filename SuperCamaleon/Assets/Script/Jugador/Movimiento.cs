using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public float jumpForce;

    public float turnSmoothTime = 0.1f;

    float turnsmoothVelocity;

    public Transform cam;
    
    private CharacterController characterController;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw ("Vertical");

        Vector3 direccion = new Vector3 (hor,0f ,ver).normalized;

        
        if(direccion.magnitude >= 0.1f)
        {
            float targetAngle = MathF.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, turnSmoothTime);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        
        

    }
}
