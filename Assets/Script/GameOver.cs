using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public int life;
    [SerializeField]
    GameObject gameOverScreen, highscore, textMoney, retryButton, screenButton;
    private Player playerData;
    int TempMoney;
    bool isRandomize;
    bool GOCon;
    void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<Player>();
        life = 3;
        isRandomize = true;
        TempMoney = 0;
        GOCon = false;
        retryButton.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(life<=0 && !GOCon)
        {
            gameOver();   
        }

        if(isRandomize && GOCon)
        {
            rolling(textMoney);
        }
    }

    public void End()
    {
        // playerData.SavePlayer();
        SceneManager.LoadScene("Gameplay");
    }

    void gameOver()
    {
        screenButton.GetComponent<Button>().interactable = false;
        GOCon = true;
        if(playerData.adsAttempt>0)
        {
            playerData.DecAttempt();
        }
        else
        {
            GoogleAdMobController.instance.ShowInterstitialAd();
            playerData.SetAttempt();
        }
        gameOverScreen.SetActive(true);
        Scoring.AddMoney(playerData);
        Scoring.SetHighScore(playerData);
        playerData.SavePlayer();
        TempMoney = playerData.score * 3;
        highscore.GetComponent<TextMeshProUGUI>().text = playerData.highscore.ToString();
    }

    public void clearingStack()
    {
        Scoring.ClearStack(playerData);
    }

    public void DestroyingAd()
    {
        GoogleAdMobController.instance.DestroyInterstitialAd();
    }

    void rolling(GameObject textMoney)
    {
        textMoney.GetComponent<TextMeshProUGUI>().text = "$"+Random.Range(0000, 9999).ToString();
        StartCoroutine("result");
    }

    IEnumerator result()
    {
        yield return new WaitForSeconds(2f);
        textMoney.GetComponent<TextMeshProUGUI>().text = "$"+TempMoney;
        isRandomize = false;
        Scoring.ClearStack(playerData);
        retryButton.GetComponent<Button>().interactable = true;
    }
}
