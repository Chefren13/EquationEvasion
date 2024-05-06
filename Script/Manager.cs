using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject rulesText;
    public GameObject HowToPlay;
    public GameObject slope;
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RulesButton()
    {
        rulesText.SetActive(true);
        HowToPlay.SetActive(true);
        slope.SetActive(false);
    }

    public void Slope()
    {
        slope.SetActive(true);
        rulesText.SetActive(false);
        HowToPlay.SetActive(false);
    }
}
