using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplaySetup : MonoBehaviour
{
    [SerializeField]
    GameObject player, score, building, building2, scoreImage, scoreText, rope, audiosource, boxaudio;

    public List<GedungData> gedung = new List<GedungData>();
    Player playerData;
    int checkpoint = 10;
    // Start is called before the first frame update
    void Awake()
    {
        building.GetComponent<SpriteRenderer>().sprite = gedung[PlayerPrefs.GetInt("UsedItem")].image;
        building2.GetComponent<SpriteRenderer>().sprite = gedung[PlayerPrefs.GetInt("UsedItem")].image2;
        scoreImage.GetComponent<Image>().sprite = gedung[PlayerPrefs.GetInt("UsedItem")].image2;
    }

    void Start()
    {
        player = GameObject.Find("Player");
        playerData = player.GetComponent<Player>();
        SetSound();
        if(playerData.adsAttempt==0)
        {
            GoogleAdMobController.instance.RequestAndLoadInterstitialAd();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerData.score<0)
        {
            scoreText.GetComponent<TextMeshProUGUI>().text = "x" + 0;
        }
        else
        {
            scoreText.GetComponent<TextMeshProUGUI>().text = "x"+playerData.score.ToString();
        }

        if(playerData.score>checkpoint)
        {
            checkpoint+=10;
            rope.GetComponent<Pendulum>().moveSpeed+=5f;
        }
        
    }

    public void SetSound()
    {
        audiosource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music");
        boxaudio.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music");
    }

   

}
