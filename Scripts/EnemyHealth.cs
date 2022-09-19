using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public Slider enemySlider3D;

    Stats statsScript;


    // Start is called before the first frame update
    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Stats>();

        enemySlider3D.maxValue = statsScript.maxHealth;
        statsScript.health = statsScript.maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        this.enemySlider3D.value = statsScript.health;
    }
}
