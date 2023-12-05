using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{

    public GameObject GameOverPanel;
    public GameObject DangerPanel;
    Color GameOver_color;
    Color Danger_color;

    [SerializeField] Button GameOverButton;
    [SerializeField] Button DangerButton;

    [SerializeField] float danger_speed = 2f;
    [SerializeField] float danger_min = 0f;
    [SerializeField] float danger_max = 1f;

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
            GameOverPanel.GetComponent<Image>().color = GameOver_color;
        }
        else GameOverReady = false;

        if(DangerReady)
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

    public void onClickGameOverButton()
    {
        GameOverPanel.SetActive(true);
        DangerPanel.SetActive(false);

        GameOver_color = GameOverPanel.GetComponent<Image>().color;
        GameOver_color.a = 0f;
        GameOverPanel.GetComponent<Image>().color = GameOver_color;

        GameOverReady = true;
        DangerReady = false;
    }

    public void onClickDangerButton()
    {
        GameOverPanel.SetActive(false);
        DangerPanel.SetActive(true);

        Danger_color = DangerPanel.GetComponent<Image>().color;
        Danger_color.a = danger_min;
        isUp = true;
        DangerPanel.GetComponent<Image>().color = Danger_color;

        GameOverReady = false;
        DangerReady = true;
    }
}
