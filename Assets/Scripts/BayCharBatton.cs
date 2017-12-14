using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayCharBatton : MonoBehaviour {

    public int price = 100;
    public GameObject NotTokensPanel;

    void Start()
    {
        if (PlayerPrefs.HasKey(gameObject.name) == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void CheckToken()
    {
        if (GameControl.instance.totalScore >= price)
        {
            GameControl.instance.totalScore -= price;
            PlayerPrefs.SetString(gameObject.name, "true");
            GameControl.instance.SaveScore();
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(OpenNotTokensPanel());
        }
        
    }
    IEnumerator OpenNotTokensPanel()
    {
        NotTokensPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        NotTokensPanel.SetActive(false);
    }
}
