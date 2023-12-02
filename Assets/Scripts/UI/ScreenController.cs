using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{

    public GameObject GameOverPanel;
    public GameObject DangerPanel;
    Color GameOver_color;

    [SerializeField] Button GameOverButton;
    [SerializeField] Button DangerButton;

    bool GameOverReady = false;

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        DangerPanel.SetActive(false);

        GameOver_color = GameOverPanel.GetComponent<Image>().color;
        GameOver_color.a = 0f;
        GameOverPanel.GetComponent<Image>().color = GameOver_color;
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
    }

    public void onClickGameOverButton()
    {
        GameOverPanel.SetActive(true);
        DangerPanel.SetActive(false);

        GameOver_color = GameOverPanel.GetComponent<Image>().color;
        GameOver_color.a = 0f;
        GameOverPanel.GetComponent<Image>().color = GameOver_color;

        GameOverReady = true;
    }

    public void onClickDangerButton()
    {
        GameOverPanel.SetActive(false);
        DangerPanel.SetActive(true);
    }
}
