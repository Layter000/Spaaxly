using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

    public GameObject TutorialText;

    private bool isStart = false;

	void Start () {
       GameControl.instance.OnGameRestart += Restart;
    }

	void Update () {
        if (PlayerPrefs.HasKey("isNotNeededTutorial") == false && isStart == false && GameControl.instance.isStart == true)
        {
            StartCoroutine(OnTutorialText());
            
            isStart = true;
        }
        if (GameControl.instance.totalScore > 5)
        {
            PlayerPrefs.SetString("isNotNeededTutorial"," ");
        }
    }
    IEnumerator OnTutorialText()
    {
        TutorialText.SetActive(true);
        yield return new WaitForSeconds(2f);
        TutorialText.SetActive(false);
    }

    void Restart()
    {
        isStart = false;
    }
}
