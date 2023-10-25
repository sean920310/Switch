using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem.Model
{
    [CreateAssetMenu(fileName = "NewBuffData", menuName = "Buff/Create FunctionalBuff Data")]
    public class FunctionalBuffSO : BuffSO
    {
        override public void ApplyBuff(PlayerEntity playerEntity)
        {
            playerEntity.OnDamageCallback += DamageReflect;
        }

        override public void RemoveBuff(PlayerEntity playerEntity)
        {
            playerEntity.OnDamageCallback -= DamageReflect;
        }
        public void DamageReflect(EntityBase enemyEntity, float damage)
        {
            enemyEntity.GetDamage(enemyEntity, damage);
        }
    }
}
