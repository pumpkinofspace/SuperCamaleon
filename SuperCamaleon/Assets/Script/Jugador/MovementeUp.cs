using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementeUp : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothSuavecity;

    public float gravity = 9.81f;
    float yVelocity = 0f;
    bool isGrounded;

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
        isGrounded = controller.isGrounded;

        if (!isGrounded)
        {
            yVelocity -= gravity * Time.deltaTime;
        }
        else
        {
            yVelocity = -0.5f; // Si está en el suelo, restablecer la velocidad a un valor pequeño
        }

        // Salto
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("saltando");
                yVelocity = Mathf.Sqrt(jumpForce * 2f * gravity);
                isJumping = true;
            }
        }

        Vector3 verticalVelocity = Vector3.up * yVelocity;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
}
