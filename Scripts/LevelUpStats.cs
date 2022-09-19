using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpStats : MonoBehaviour
{
    public int level = 1;
    public float experience {get; private set; }
    public Text lvlText;
    public Image expBarImage;


    public static int ExpToLvlUp(int currentLevel)
    {
    if(currentLevel == 0)
        {
            return 0;
        }
    return (currentLevel * currentLevel + currentLevel) * 5;
    }

    public void SetExperience(float exp)
    {
        experience += exp;

        float expNeeded = ExpToLvlUp(level);
        float previousExperience = ExpToLvlUp(level-1);

        if(experience >= expNeeded)
        {
            LevelUp();
            expNeeded = ExpToLvlUp(level);
            previousExperience = ExpToLvlUp(level - 1);

        }

        expBarImage.fillAmount = (experience - previousExperience) / (expNeeded - previousExperience);

        if(expBarImage.fillAmount == 1)
        {
            expBarImage.fillAmount = 0;
        }

    }

    public void LevelUp()
    {
        level++;
        lvlText.text = level.ToString("");
    }
}
