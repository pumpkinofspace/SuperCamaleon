using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    [SerializeField]
    public float boing;
    public GameObject jugador; 



    private void OnCollisionEnter(Collision collision)
    {
        
        
        if(collision.gameObject.tag == "Player")
        {
           
           jugador.GetComponent<MovementeUp>().saltoTrampolin(boing);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            jugador.GetComponent<MovementeUp>().saltoTrampolin(boing);
        }

    }


}
