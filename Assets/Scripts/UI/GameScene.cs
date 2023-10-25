using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public SettingPage settingPage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    public void OnHomeBtnClicked()
    {
        SceneManager.LoadScene("Lobby");
    }
}
