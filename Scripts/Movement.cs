using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float rotateSpeedMovement = 0.075f;
    public float rotateVelocity;


    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                
                    agent.SetDestination(hit.point);
                    agent.stoppingDistance = 0;

                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationToLookAt.eulerAngles.y,
                        ref rotateVelocity,
                        rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);  
            }
        }
    }
}
