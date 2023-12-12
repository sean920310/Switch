using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : PersistentSingleton<ScreenController>
{

    public GameObject GameOverPanel;
    public GameObject GameWinPanel;
    public GameObject DangerPanel;
    Color GameOver_color;
    Color GameWin_color;
    Color Danger_color;

    [SerializeField] float danger_speed = 2f;
    [SerializeField] float danger_min = 0f;
    [SerializeField] float danger_max = 1f;

    bool GameWinReady = false;
    bool GameOverReady = false;
    bool DangerReady = false;
    bool isUp = true;

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        DangerPanel.SetActive(false);

        GameOver_color = GameOverPanel.GetComponent<Image>().color;
        GameOver_color.a = 0f;
        GameOverPanel.GetComponent<Image>().color = GameOver_color;

        GameWin_color = GameWinPanel.GetComponent<Image>().color;
        GameWin_color.a = 0f;
        GameWinPanel.GetComponent<Image>().color = GameWin_color;

        Danger_color = DangerPanel.GetComponent<Image>().color;
        Danger_color.a = danger_min;
        DangerPanel.GetComponent<Image>().color = Danger_color;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver_color = GameOverPanel.GetComponent<Image>().color;
        if (GameOverReady && GameOver_color.a < 1f)
        {
            GameOver_color.a += Time.deltaTime;
            if (GameOver_color.a >= 1.0)
            {
                GameOver_color.a = 1f;
            }
            GameOverPanel.GetComponent<Image>().color = GameOver_color;
        }
        else GameOverReady = false;

        GameWin_color = GameOverPanel.GetComponent<Image>().color;
        if (GameOverReady && GameWin_color.a < 1f)
        {
            GameWin_color.a += Time.deltaTime;
            if (GameWin_color.a >= 1.0)
            {
                GameWin_color.a = 1f;
            }
            GameWinPanel.GetComponent<Image>().color = GameWin_color;
        }
        else GameWinReady = false;

        if (DangerReady)
        {
            Danger_color = DangerPanel.GetComponent<Image>().color;
            if (Danger_color.a < danger_max && isUp)
            {
                Danger_color.a += Time.deltaTime * danger_speed;
                DangerPanel.GetComponent<Image>().color = Danger_color;
            }
            else if (Danger_color.a >= danger_max)
            {
                isUp = false;
                Danger_color.a -= Time.deltaTime * danger_speed;
                DangerPanel.GetComponent<Image>().color = Danger_color;
            }
            else if (Danger_color.a <= danger_min)
            {
                isUp = true;
                Danger_color.a += Time.deltaTime * danger_speed;
                DangerPanel.GetComponent<Image>().color = Danger_color;
            }
            else if (danger_min < Danger_color.a && !isUp)
            {
                Danger_color.a -= Time.deltaTime * danger_speed;
                DangerPanel.GetComponent<Image>().color = Danger_color;
            }
        }
    }

    public void OnGameOver()
    {
        GameOverPanel.SetActive(true);
        GameWinPanel.SetActive(false);
        DangerPanel.SetActive(false);

        GameOver_color = GameOverPanel.GetComponent<Image>().color;
        GameOver_color.a = 0f;
        GameOverPanel.GetComponent<Image>().color = GameOver_color;

        GameOverReady = true;
        GameWinReady = false;
        DangerReady = false;
    }
    public void OnGameWin()
    {
        GameWinPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        DangerPanel.SetActive(false);

        GameWin_color = GameOverPanel.GetComponent<Image>().color;
        GameWin_color.a = 0f;
        GameWinPanel.GetComponent<Image>().color = GameWin_color;

        GameWinReady = true;
        GameOverReady = false;
        DangerReady = false;
    }

    public void OnDanger()
    {
        DangerPanel.SetActive(true);

        Danger_color = DangerPanel.GetComponent<Image>().color;
        Danger_color.a = danger_min;
        isUp = true;
        DangerPanel.GetComponent<Image>().color = Danger_color;

        DangerReady = true;
    }

    public void DangerOff()
    {
        DangerPanel.SetActive(false);

        Danger_color = DangerPanel.GetComponent<Image>().color;
        Danger_color.a = danger_min;
        isUp = true;
        DangerPanel.GetComponent<Image>().color = Danger_color;

        DangerReady = false;
    }
}
