using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int money;
    public int highscore;
    public int[] unclokacbleBuilding;
    // int index = 0;

    public PlayerData(Player player)
    {
        money = player.money;
        highscore = player.highscore;
        unclokacbleBuilding = player.unlockableBuilding;
        // unclokacbleBuilding[0] = 1;
        // foreach(int x in player.unlockableBuilding)
        // {
            
        //     Debug.Log(x);
        //     index++;
        // }

    }
}
