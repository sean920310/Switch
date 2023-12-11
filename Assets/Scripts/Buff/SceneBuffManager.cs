using BuffSystem;
using BuffSystem.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuffManager : PersistentSingleton<SceneBuffManager>
{
    [SerializeField]
    private PlayerEntity m_playerEntity;

    [SerializeField]
    private BuffCards m_buffCard;
    [SerializeField]
    private BuffSO[] m_buffPool;
    [SerializeField]
    private List<BuffSO> m_chooseBuffList;

    [SerializeField]
    private int m_buffCount = 3;

    private bool m_isAppQuiting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("PlayerGetBuff")]
    public void PlayerGetBuff()
    {
        m_buffCard.enabled = false;

        ChooseBuffFromBuffPool();

        SetBuffUIFronChoosenBuff();

        m_buffCard.GetComponent<Animator>().Play("Card_Show");

        Time.timeScale = 0.0f;


    }

    private void ChooseBuffFromBuffPool()
    {
        if (m_buffCount > m_buffPool.Length)
        {
            Debug.LogWarning("Can't Choose Stage: Stage pool count not enough!");
            return;
        }

        // Clear Chosen Stages
        m_chooseBuffList.Clear();

        // Ramdon Pick Stages In Stage Pool (Non-repetitive)
        HashSet<int> uniqueNumbers = new HashSet<int>();

        while (uniqueNumbers.Count < m_buffCount)
        {
            int randomNumber = Random.Range(0, m_buffPool.Length);
            uniqueNumbers.Add(randomNumber);
        }

        foreach (int number in uniqueNumbers)
        {
            m_chooseBuffList.Add(m_buffPool[number]);
        }

    }

    private void SetBuffUIFronChoosenBuff()
    {
        for(int i = 0; i < m_buffCount; i++)
        {
            m_buffCard.SetBuffCard(i, m_chooseBuffList[i].description, m_chooseBuffList[i].buffIcon);
        }
    }

    private void OnBuffClicked(int idx)
    {
        m_playerEntity.GetComponent<BuffManager>().AddBuff(m_chooseBuffList[idx]);
        m_buffCard.GetComponent<Animator>().Play("Card_Hide");

        Time.timeScale = 1.0f;
    }

    private void OnEnable()
    {
        m_buffCard.onBuffClicked += OnBuffClicked;
    }

    private void OnDisable()
    {
        if (!m_isAppQuiting)
        {
            m_buffCard.onBuffClicked -= OnBuffClicked;
        }
    }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }

}
