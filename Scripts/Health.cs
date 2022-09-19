using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Slider playerSlider3D;
    public Slider playerSlider2D;

    Stats statsScript;


    // Start is called before the first frame update
    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();

        playerSlider3D.maxValue = statsScript.maxHealth;
        playerSlider2D.maxValue = statsScript.maxHealth;
        statsScript.health = statsScript.maxHealth;


    }

    // Update is called once per frame
    void Update()
    {
        playerSlider3D.value = statsScript.health;
        playerSlider2D.value = playerSlider3D.value;
    }
}

