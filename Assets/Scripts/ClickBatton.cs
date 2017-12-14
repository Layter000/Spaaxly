using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickBatton : MonoBehaviour {

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    public void ActiveOjectOff(GameObject window)
    {
        window.SetActive(false);
    }
    public void ActiveOjectOn(GameObject window)
    {
        window.SetActive(true);
    }
    public void VolumeOnOfBatton()
    {
        if (!GameControl.instance.isVolume)
        {
            GameControl.instance.isVolume = true;
        }
        else
        {
            GameControl.instance.isVolume = false;
        }
    }

}
