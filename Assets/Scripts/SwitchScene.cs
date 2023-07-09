using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public bool autoSwitchAfterTime;
    public string autoScene;
    public float autoTime;

    public void Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    void Update()
    {
        if(autoSwitchAfterTime && Time.timeSinceLevelLoad >= autoTime)
        {
            Scene(autoScene);
        }
    }
}
