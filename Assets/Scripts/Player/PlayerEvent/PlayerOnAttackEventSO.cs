using UnityEngine;

/// <summary>
/// Player Get Damaged Channel
/// </summary>
[CreateAssetMenu(fileName = "PlayerOnAttackEventSO", menuName = "Player Event/Create PlayerOnAttackEventSO")]
public class PlayerOnAttackEventSO : ScriptableObject, IOnPlayerAttackEvent
{
    private IEntityEvent<EntityBase, EntityBase, float>.OnEntityEvent m_OnPlayerAttackEvent;


    public IEntityEvent<EntityBase, EntityBase, float>.OnEntityEvent EntityEvent => m_OnPlayerAttackEvent;

    public void RaiseEntityEvent(EntityBase victimEntity, EntityBase enemyEntity, float value)
    {
        m_OnPlayerAttackEvent?.Invoke(victimEntity, enemyEntity, value);
    }
}
