using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    [SerializeField]
    public GameObject player, money, eventsystem, building, building2, audiosource;
    // Start is called before the first frame update
    public int sliderValue;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        money.GetComponent<TextMeshProUGUI>().text = "$" + player.GetComponent<Player>().money.ToString();
        // eventsystem.GetComponent<Shop>().gedung;
        checkKey();
        if(PlayerPrefs.HasKey("Music"))
        {
            SetSound();
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
            SetSound();
        }
        SetSound();
        updateBuild(eventsystem.GetComponent<Shop>().gedung);
        
    }

    public void updateBuild(List<GedungData> gedungData)
    {
        
        if(player.GetComponent<Player>().unlockableBuilding != null)
        {
            foreach(int x in player.GetComponent<Player>().unlockableBuilding)
            {
                gedungData[x].owned = true;
            }
            building.GetComponent<SpriteRenderer>().sprite = gedungData[player.GetComponent<Player>().buildingUsed].image;
            building2.GetComponent<SpriteRenderer>().sprite = gedungData[player.GetComponent<Player>().buildingUsed].image2;
        }     
           
        
    }

    void checkKey()
    {
        if(PlayerPrefs.HasKey("UsedItem"))
        {
            player.GetComponent<Player>().buildingUsed = PlayerPrefs.GetInt("UsedItem");
        }
        else
        {
            PlayerPrefs.SetInt("UsedItem", 0);
            player.GetComponent<Player>().buildingUsed = 0;
        }
    }

    public void LoadSound(Slider slider)
    {
        slider.value = PlayerPrefs.GetFloat("Music");
    }

    public void SetSound()
    {
        audiosource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music");
    }

    public void SaveSound(Slider slider)
    {
        PlayerPrefs.SetFloat("Music", slider.value);
    }
}
