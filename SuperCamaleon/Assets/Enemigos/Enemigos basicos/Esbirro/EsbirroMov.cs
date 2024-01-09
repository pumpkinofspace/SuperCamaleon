using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EsbirroMov : MonoBehaviour
{
    [SerializeField]
    Transform destino;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("No asignaste un nav mesh agent al enemigo mama huevo" + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        if(destino != null)
        {
            Vector3 targetVector = destino.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
    }
}
