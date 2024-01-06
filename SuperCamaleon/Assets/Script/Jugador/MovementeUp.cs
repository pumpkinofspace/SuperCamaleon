using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementeUp : MonoBehaviour
{
    public CharacterController controller;

    public float speed;

    public float turnSmoothTime = 0.1f;

    float turnSmoothSuavecity;

    public float gravedad = 9.81f; 



    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direcion = new Vector3(horizontal, 0f, vertical).normalized;

        transform.position.y += gravedad * Time.deltaTime;


        if(direcion.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direcion.x, direcion.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothSuavecity, turnSmoothTime);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            


            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
