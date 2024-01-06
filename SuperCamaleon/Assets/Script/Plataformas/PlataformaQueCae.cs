using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaQueCae : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 inicio;
    public float tiempoEsperar; 
    public float tiempoVolver;
    private float contador;
    private bool bandera;
    private bool regresar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inicio = transform.position; 

        bandera = false;
        regresar = false;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(bandera)
        {
            contador += Time.deltaTime;
            
            if(contador > tiempoEsperar ) 
            { 
                rb.useGravity = true;
                rb.mass = 500f;
                regresar = true;
                bandera=false;
                contador=0;
            }
        }else if(regresar) 
        { 
            contador += Time.deltaTime;
            if( contador > tiempoVolver)
            {
                transform.position = inicio;
                regresar = false;
                rb.useGravity=false;
                rb.mass = 10000f;
                contador = 0;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bandera = true;
            Debug.Log("touched");
        }
    }
}
