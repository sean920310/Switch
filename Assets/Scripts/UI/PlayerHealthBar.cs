using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField]
    private Image m_healthBar;

// Start is called before the first frame update
    void Start()
    {
        SetHealth(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(float health)
    {
        m_healthBar.fillAmount = health;
    }
}
