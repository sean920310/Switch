using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] float m_spikeDamage = 10.0f;

    [SerializeField] bool m_isPlayerInTrap = false;
    [SerializeField] float m_spikeDamageCD = 1.5f;

    private IEnumerator m_hurtPlayerCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerEntity playerEntity = other.GetComponent<PlayerEntity>();
        if(other.name == "Player" && playerEntity != null)
        {

            m_isPlayerInTrap = true;
            m_hurtPlayerCoroutine = HurtPlayerCunoroutine(playerEntity);
            StartCoroutine(m_hurtPlayerCoroutine);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerEntity playerEntity = other.GetComponent<PlayerEntity>();
        if (other.name == "Player" && playerEntity != null)
        {
            m_isPlayerInTrap = false;

            if (m_hurtPlayerCoroutine != null)
                StopCoroutine(m_hurtPlayerCoroutine);
        }
    }

    public IEnumerator HurtPlayerCunoroutine(PlayerEntity playerEntity)
    {
        while (m_isPlayerInTrap)
        {
            Debug.Log("playerEntity: " + playerEntity);
            playerEntity?.GetDamage(null, m_spikeDamage);
            yield return new WaitForSeconds(m_spikeDamageCD);
        }
    }
}
