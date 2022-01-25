using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int money = 0;
    public int highscore = 0;
    public int score = 0;
    public int[] unlockableBuilding;
    public int buildingUsed;
    public List<GameObject> stacking = new List<GameObject>();
    public int adsAttempt;
    // public List<int> unlockableBuilding = new List<int>();
    public static Player playerInstance;

    [System.Obsolete]
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
        if(!PlayerPrefs.HasKey("JatahSehari"))
        {
            PlayerPrefs.SetInt("JatahSehari", 7);
        }


        if(PlayerPrefs.HasKey("Attempt"))
        {
            adsAttempt = PlayerPrefs.GetInt("Attempt");
        }
        else
        {
            SetAttempt();
        }
        
        if (playerInstance == null) {
            playerInstance = this;
        } else {
            DestroyObject(gameObject);
        }
        LoadPlayer();    
    }

    public void DecAttempt()
    {
        adsAttempt -= 1;
        PlayerPrefs.SetInt("Attempt", adsAttempt);
    }

    public void SetAttempt()
    {
        adsAttempt = Random.Range(2,5);
        PlayerPrefs.SetInt("Attempt", adsAttempt);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        money = data.money;
        highscore = data.highscore;
        unlockableBuilding = data.unclokacbleBuilding;
        // foreach(int x in data.unclokacbleBuilding)
        // {
        //     unlockableBuilding.Add(x);
        // }
        
    }

    
    
}
