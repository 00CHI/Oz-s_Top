using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Setting01 : MonoBehaviour
{
    public void BackMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void GetSetting()
    {
        SceneManager.LoadScene("Setting");
    }
}
