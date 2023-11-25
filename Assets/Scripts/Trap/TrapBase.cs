using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class TrapBase : MonoBehaviour
{
    [Header("Trap Base")]
    [SerializeField] protected float m_trapDamage = 10.0f;

    [SerializeField] protected bool m_isPlayerInTrap = false;
    [SerializeField] protected float m_trapDamageCD = 1.5f;

    [SerializeField] protected bool m_isDoingDamage = true;

    private IEnumerator m_hurtPlayerCoroutine;

    public delegate void PlayerTriggerEvent();
    public event PlayerTriggerEvent playerEnterTrigger;
    public event PlayerTriggerEvent playerExitTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerEntity playerEntity = other.GetComponent<PlayerEntity>();
        if (other.name == "Player" && playerEntity != null)
        {
            m_isPlayerInTrap = true;

            playerEnterTrigger?.Invoke();

            if (m_isDoingDamage)
            {
                m_hurtPlayerCoroutine = HurtPlayerCunoroutine(playerEntity);
                StartCoroutine(m_hurtPlayerCoroutine);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerEntity playerEntity = other.GetComponent<PlayerEntity>();
        if (other.name == "Player" && playerEntity != null)
        {
            m_isPlayerInTrap = false;
            playerExitTrigger?.Invoke();
            if (m_hurtPlayerCoroutine != null && m_isDoingDamage)
            {
                StopCoroutine(m_hurtPlayerCoroutine);
            }
        }
    }

    public IEnumerator HurtPlayerCunoroutine(PlayerEntity playerEntity)
    {
        while (m_isPlayerInTrap)
        {
            Debug.Log("playerEntity: " + playerEntity);
            playerEntity?.GetDamage(null, m_trapDamage);
            yield return new WaitForSeconds(m_trapDamageCD);
        }
    }
}
