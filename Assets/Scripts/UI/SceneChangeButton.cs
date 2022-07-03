using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    public string SceneName;
    public void SceneChange()
    {
        PlayerPrefs.SetInt("GScore", 0);
        PlayerPrefs.SetInt("LC", 0);
        PlayerPrefs.SetInt("L", 0);
        SceneManager.LoadScene(SceneName);

    }
}
