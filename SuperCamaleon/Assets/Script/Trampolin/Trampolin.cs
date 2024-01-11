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

        MovementeUp characterController = collision.gameObject.GetComponent<MovementeUp>();

        if (characterController != null)
        {
            characterController.saltoTrampolin(boing);
        }

    }
    

}
