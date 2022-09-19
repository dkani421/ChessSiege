using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pawn : MonoBehaviour
{
    public Transform Playerpos;
    public NavMeshAgent agent;

    Vector3 rot = new Vector3(-90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.transform.Rotate(rot);
        agent.destination = Playerpos.position;
        agent.stoppingDistance = 0.25F;

    }
}
