using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTargeting : MonoBehaviour
{

    public GameObject selectedHero;
    public bool heroPlayer;
    RaycastHit hit;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
               


                if (hit.collider.GetComponent<Targetable>())
                {
                    
                    if (hit.collider.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
                    {
                        selectedHero.GetComponent<HeroCombat>().targetedEnemy = hit.collider.gameObject;
                    }
                }
                else if (hit.collider.GetComponent<Targetable>() == null)
                {
                    selectedHero.GetComponent<HeroCombat>().targetedEnemy = null;

                }
            }
        }

        
    }
}
