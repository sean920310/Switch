using UnityEngine;

/// <summary>
/// Player Get Damaged Channel
/// </summary>
[CreateAssetMenu(fileName = "PlayerOnDamageEventSO", menuName = "Player Event/Create PlayerOnDamageEventSO")]
public class PlayerOnDamageEventSO : ScriptableObject, IOnPlayerDamageEvent
{
    private IEntityEvent<EntityBase, EntityBase, float>.OnEntityEvent m_OnPlayerDamageEvent;


    public IEntityEvent<EntityBase, EntityBase, float>.OnEntityEvent EntityEvent => m_OnPlayerDamageEvent;

    public void RaiseEntityEvent(EntityBase victimEntity, EntityBase enemyEntity, float value)
    {
        m_OnPlayerDamageEvent?.Invoke(victimEntity, enemyEntity, value);
    }
}
