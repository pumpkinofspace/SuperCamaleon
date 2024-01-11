using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    [SerializeField]
    public float boing;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        CharacterController characterController = collision.gameObject.GetComponent<CharacterController>();

        if (characterController != null)
        {
            characterController.Move(Vector3.up * boing);
        }

    }

}
