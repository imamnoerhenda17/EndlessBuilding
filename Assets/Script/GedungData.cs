using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GedungData
{
    public Sprite image;
    public Sprite image2;
    public int price;
    public bool owned;

    public void generateEvent(Sprite newImage, Sprite newImage2, int newPrice, bool isOwned)
    {
        image = newImage;
        image2 = newImage2;
        price = newPrice;
        owned = isOwned;
    }
    
}
