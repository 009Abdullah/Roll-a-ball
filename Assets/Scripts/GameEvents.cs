using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    public static event Action<string, float> EnemyHealthUpdated;

    public static void EnemyHealthUpdate(string name,float health)
    {
        EnemyHealthUpdated?.Invoke(name, health);
    }
}
