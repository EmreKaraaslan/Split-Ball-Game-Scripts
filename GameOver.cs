using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI crashUI;
    [SerializeField] TextMeshProUGUI coinUI;
    [SerializeField] TextMeshProUGUI fallDownUI;
    [SerializeField] GameObject speedUI;
    [SerializeField] GameObject RestartButton;

    [SerializeField] int collectedCoin;
    void Start()
    {
        crashUI.text = "";
        fallDownUI.text = "";
        speedUI.SetActive(false);
        RestartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayColledtedCoin();
    }

    private void DisplayColledtedCoin()
    {
    
        coinUI.text = "Point: " + collectedCoin.ToString();
    }

    public void IncreaseColledtedCoin()
    {
        collectedCoin++;
    }


    public void FinishGameCrash()
    {
        
        crashUI.text = "Crash!";
        Invoke("RestartButtonActivate", 1f);
    }

    public void RestartButtonActivate()
    {
        RestartButton.SetActive(true);
        Time.timeScale = 0;
    }
    public void FinishGameFallDown()
    {
        fallDownUI.text = "      You Fell Down!";
        Invoke("RestartButtonActivate", 1f);
    }

   public void Restart()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    public void SpeedUIAction()
    {
        speedUI.SetActive(true);
        Invoke("CloseSpeedUI", 0.5f);
    }

    void CloseSpeedUI()
    {
        speedUI.SetActive(false);
    }
}
