
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using BuffSystem.Model;
using JetBrains.Annotations;

[CreateAssetMenu(fileName = "StunBuffAction", menuName = "Buff/Create StunBuffAction")]
public class StunBuffAction : ScriptableObject, IOnPlayerAttackAction
{
    [SerializeField]
    [Range(0.0f, 1.0f)] private float m_stunProbability; // 0.0 ~ 1.0

    // On Player Damage Action, this is about damage reflection.
    public void EntityAction(EntityBase victimEntity, EntityBase enemyEntity, float value)
    {

        if (enemyEntity != null && victimEntity != enemyEntity)
        {
            float prob = UnityEngine.Random.Range(0, 100);
            if (prob < m_stunProbability)
            {
                Debug.Log("Stun Successed");
            }
            else
            {
                Debug.Log("Stun failed");
            }
        }
    }
}
