using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRigs : MonoBehaviour
{
    public Enemy enemy;
    public float multiplier;

    public void Take_Damage(float amount)
    {
        enemy.Take_Damage(amount * multiplier);
    }
}
