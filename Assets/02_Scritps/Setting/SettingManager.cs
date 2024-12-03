using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SettingManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject exitPanel;
    public GameObject keyPanel;
    public GameObject buttonPanel;

    int settingCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        settingPanel.SetActive(false);
        exitPanel.SetActive(false);
        keyPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)&& settingCount == 0)
        {
            settingPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Stage0");
    }
    public void InSettingScene()
    {
        SceneManager.LoadScene("Setting");
    }
    public void BackGame()
    {
        settingPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void BackSetting()
    {
        settingPanel.SetActive(true);
        exitPanel.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void RealExitPanel()
    {
        settingPanel.SetActive(false);
        exitPanel.SetActive(true);
    }
    public void BackMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void OpenKey()
    {
        keyPanel.SetActive(true);
        buttonPanel.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void BackKey()
    {
        keyPanel.SetActive(false);
        buttonPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
