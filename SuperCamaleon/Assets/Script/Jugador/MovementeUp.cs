using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementeUp : MonoBehaviour
{
    [SerializeField]
    public CharacterController controller;

    public float speed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothSuavecity;

    public float gravity = 9.81f;
    float yVelocity = 0f;
    bool isGrounded;
    bool isGroundedController;


    public float raycastDistance = 0.2f;

    public float jumpForce = 5f; // Fuerza del salto
    bool isJumping = false;

    public Transform cam;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothSuavecity, turnSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Aplicar gravedad
        isGrounded = CheckIfGrounded();
        isGroundedController = controller.isGrounded;

        if (!isGroundedController)
        {
            yVelocity -= gravity * Time.deltaTime;
        }
        else
        {
            yVelocity = -0.5f; // Si está en el suelo, restablecer la velocidad a un valor pequeño
        }

        // Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
                saltoFuncion();
            
        }else if (isJumping) {
            yVelocity -= gravity * Time.deltaTime;
        }

        Vector3 verticalVelocity = Vector3.up * yVelocity;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    bool CheckIfGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }
    

    void saltoFuncion()
    {
        // Debug.Log("saltando");
        yVelocity = Mathf.Sqrt(jumpForce * 2f * gravity);
        isJumping = true;
    }

    public void saltoTrampolin(float fuerzaSalto)
    {
       // float noSalto = transform.position.y;
        Debug.Log("LLegamos hasta aqui");
        yVelocity = Mathf.Sqrt(fuerzaSalto * 2f * gravity);
        isJumping = true;
       

    }

    
}
