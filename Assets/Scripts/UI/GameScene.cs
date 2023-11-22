using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public SettingPage settingPage;
    public TeachingPage teachingPage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (teachingPage.IsOn)
            {
                teachingPage.Close();
            }
            else
            {
                OnSettingBtnClicked();
            }
        }
    }

    public void OnSettingBtnClicked()
    {
        Debug.Log(settingPage.IsOn);
        if (settingPage.IsOn)
        {
            settingPage.Close();
        }
        else
        {
            settingPage.Open();
        };
    }

    public void OnTeachingBtnClicked()
    {
        Debug.Log(teachingPage.IsOn);
        if (teachingPage.IsOn)
        {
            teachingPage.Close();
        }
        else
        {
            teachingPage.Open();
        };
    }

    public void OnHomeBtnClicked()
    {
        SceneManager.LoadScene("Lobby");
    }
}
