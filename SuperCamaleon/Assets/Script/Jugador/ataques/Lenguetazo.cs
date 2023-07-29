using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lenguetazo : MonoBehaviour
{

    private LineRenderer lr;
    private Vector3 puntoDeAgarre;
    public LayerMask CosasAgarrables;
    //hacer mejoras respecto a luego sea que se mueva la cabeza
    public Transform gafas, camera, player;

    private SpringJoint joint;

    [SerializeField] private float maxDistance;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    //aqui tengo que hacer que sea por mando por el momento sera por mouse
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }

        
    }


    private void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
        {
            puntoDeAgarre = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = puntoDeAgarre;

            float distanciaEntreElPunto = Vector3.Distance(player.position, puntoDeAgarre);

            //la distancia que sucede entre ambos puntos y todo este en orden
            joint.maxDistance = distanciaEntreElPunto * 0.8f;
            joint.minDistance = distanciaEntreElPunto * 0.25f;
        }
    }

    private void StopGrapple()
    {

    }


}
