using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Scoring
{
    public static void AddScore(Player player)
    {
        player.score += 1;
    }

    public static void DecScore(Player player)
    {
        if(player.score==0)
        {
            player.score = 0;
        }
        else
        {
            player.score -= 1;
        }
        
    }

    public static void SetHighScore(Player player)
    {
        if(player.highscore<player.score)
        {
            player.highscore = player.score;
            player.SavePlayer();
        }
    }

    //untuk stack box pada gameplay
    public static void PushStack(Player player, GameObject box)
    {
        player.stacking.Add(box);
        if(player.stacking.Count>5)
        {
            Debug.Log(player.stacking[0] == null);
            if(player.stacking[0] != null)
            {
                player.stacking[0].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            }            
            PopStack(player, 0);
        }
    }

    public static void ClearStack(Player player)
    {
        player.stacking.Clear();
        player.score = 0;
    }

    public static void PopStack(Player player, int pos)
    {
        //pos 0 = awal, 1 = akhir
        // Debug.Log("Jumlah data pada Stack = "+player.stacking.Count);
        if(pos==1)
        {
            player.stacking.RemoveAt(player.stacking.Count-1);
        }
        else
        {
            player.stacking.RemoveAt(0);
        }
        
    }

    public static void AddMoney(Player player)
    {
        player.money += player.score * 3;
    }
}
