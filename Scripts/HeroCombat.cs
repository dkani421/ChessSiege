using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCombat : MonoBehaviour
{
    public enum HeroAttackType { Melee, Ranged};
    public HeroAttackType heroAttackType;

    public GameObject targetedEnemy;
    public float attackRange;
    public float rotateSpeedForAttack;

    private Movement moveScript;
    private Stats statScript;

    public bool basicAtkIdle = false;
    public bool isHeroAlive;

    public bool rangedOn = false;

    private bool isCoroutineExecuting = false;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Movement>();
        statScript = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W))
        {
            heroAttackType = HeroAttackType.Melee;
        }
        else if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.W))
        {
            heroAttackType = HeroAttackType.Ranged;
        }
        else if (Input.GetMouseButton(0))
        {
            heroAttackType = HeroAttackType.Melee;
        }
        */

        if (targetedEnemy != null)
        {
            if(Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange)
            {
                print("out of range");

                moveScript.agent.SetDestination(targetedEnemy.transform.position);
                moveScript.agent.stoppingDistance = attackRange;

                Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref moveScript.rotateVelocity,
                    rotateSpeedForAttack * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
            else
            {
                print("in range");
                moveScript.agent.stoppingDistance = attackRange;

                if (heroAttackType == HeroAttackType.Melee)
                {

                    StartCoroutine(MeleeAttackInterval());                  
                }
                /*
                if (heroAttackType == HeroAttackType.Ranged)
                {

                    StartCoroutine(RangedAttackInterval());
                }
                */
            }
        }

    }

    IEnumerator MeleeAttackInterval()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(statScript.attackTime / ((100.0f + statScript.attackTime) * 0.01f));

        // Code to execute after the delay
        MeleeAttack();

        isCoroutineExecuting = false;
    }

    public void MeleeAttack()
    {
        if (targetedEnemy != null)
        {
            if (targetedEnemy.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
            {
                targetedEnemy.GetComponent<Stats>().health -= statScript.attackDmg;

            }
        }
    }
    /*
    IEnumerator RangedAttackInterval() 
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(statScript.attackTime / ((100.0f + statScript.attackTime) * 0.005f));

        // Code to execute after the delay
        RangedAttack();

        isCoroutineExecuting = false;
    }

    public void RangedAttack()
    {
        if (targetedEnemy != null)
        {
            if (targetedEnemy.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
            {
                targetedEnemy.GetComponent<Stats>().health -= statScript.attackDmg+20;

            }
        }
    }
    
    */
}
