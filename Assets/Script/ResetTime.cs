using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTime : MonoBehaviour
{

    float time;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("SavedTime"))
        {
            getTime();
        }
        else
        {
            loadTime();
            if(time>1)
            {
                PlayerPrefs.SetInt("JatahSehari", 7);
            }
        }
        
    }

    public void getTime()
    {
        Debug.Log(DateTime.UtcNow);
        PlayerPrefs.SetString("SavedTime", DateTime.UtcNow.ToString());
    }

    public void loadTime()
    {
        // Debug.Log("Time Now : "+DateTime.UtcNow);
        // Debug.Log("Saved Time : "+PlayerPrefs.GetString("SavedTime"));
        DateTime before = DateTime.Parse(PlayerPrefs.GetString("SavedTime"));
        float.TryParse(DateTime.UtcNow.Subtract(before).TotalDays.ToString(), out time);
        // Debug.Log("Selisih : "+time.ToString());
    }
}
