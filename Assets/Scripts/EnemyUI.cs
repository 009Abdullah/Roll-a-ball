using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Image healthBarFill;

    private void Start()
    {

        GameEvents.EnemyHealthUpdated += UpdateHealthBar;
    }

    private void UpdateHealthBar(string enemy, float healthPercentage)
    {
       if(healthPercentage==3)
         healthBarFill.fillAmount = healthPercentage;
    }

    private void OnDestroy()
    {
        GameEvents.EnemyHealthUpdated -= UpdateHealthBar;
    }
}
