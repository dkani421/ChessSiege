using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfollow : MonoBehaviour
{
    public Transform Playerpos;
    UnityEngine.AI.NavMeshAgent agent;

    private Stats minionStats;
    private Stats playerStats;
    private HeroCombat heroCombat;
    private Movement moveScript;
    private bool isCoroutineExecuting = false;
    private bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        minionStats = GetComponent<Stats>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();

        moveScript = gameObject.GetComponent<Movement>();
        heroCombat = GetComponent<HeroCombat>();
    }
    void Update()
    {        
        if (!playerInRange)
            {
                print("out of range activate me");
                //agent.destination = Playerpos.position;
            }
        else
            {
                print("in range");
                agent.stoppingDistance = 0.25F;
                StartCoroutine(MinionAttackInterval());
            }
        }

    IEnumerator MinionAttackInterval()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(minionStats.attackTime / ((100.0f + minionStats.attackTime) * 0.01f));

        // Code to execute after the delay
        MinionAttack();

        isCoroutineExecuting = false;
    }

    public void MinionAttack()
    {
        playerStats.GetComponent<Stats>().health -= minionStats.attackDmg;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            playerInRange = false;
        }
    }

}
