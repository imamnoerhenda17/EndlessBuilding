using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    private Vector2 beginTouchPosition, endTouchPosition;
    private Touch touch;
    bool swiping;
    [SerializeField]
    GameObject objekShop, secondObject, inisiasi, text, money, buy, use, gedungImage, gedungImage2;
    [SerializeField]
    public List<GedungData> gedung = new List<GedungData>();
    private int gedungIndex;
    private Player playerData;
   
    // Start is called before the first frame update
    void Start()
    {
        swiping = false;
        gedungIndex = 0;
        playerData = GameObject.Find("Player").GetComponent<Player>();
        objekShop.GetComponent<Image>().sprite = gedung[gedungIndex].image;
        priceSetup(gedungIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
        touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                beginTouchPosition = touch.position;
                Debug.Log(beginTouchPosition);
                
                break;
            case TouchPhase.Ended:
                endTouchPosition = touch.position;
                Debug.Log(beginTouchPosition.x - endTouchPosition.x);
                
                swiping = true;
                if (beginTouchPosition.x - endTouchPosition.x > 120 )
                {
                    buttonLeft();                    
                }
                else if (beginTouchPosition.x - endTouchPosition.x < -120)
                {
                    buttonRight();
                }
                break;


        }

        }
        
    }

    public void buttonLeft()
    {
        objekShop.GetComponent<Animator>().Play("SlideOutLeft");
        objekShop.GetComponent<AnimationDestroy>().waitToDestroy();
        GameObject clone;
        clone = Instantiate(secondObject, objekShop.transform.position, Quaternion.identity, inisiasi.transform);
        //clone.transform.parent = inisiasi.transform;
        indexSetup(true);
        Image image = clone.GetComponent<Image>();
        clone.GetComponent<Animator>().enabled = false;
        clone.GetComponent<Image>().color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        clone.GetComponent<Image>().sprite = gedung[gedungIndex].image;
        priceSetup(gedungIndex);
        clone.GetComponent<Animator>().enabled = true;
        clone.GetComponent<Animator>().Play("SlideInLeft");
        objekShop = clone;
        
    }

    public void buttonRight()
    {
        objekShop.GetComponent<Animator>().Play("SlideOutRight");
        objekShop.GetComponent<AnimationDestroy>().waitToDestroy();
        GameObject clone;
        clone = Instantiate(secondObject, objekShop.transform.position, Quaternion.identity, inisiasi.transform);
        //clone.transform.parent = inisiasi.transform;
        indexSetup(false);
        Image image = clone.GetComponent<Image>();
        clone.GetComponent<Animator>().enabled = false;
        clone.GetComponent<Image>().color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        clone.GetComponent<Image>().sprite = gedung[gedungIndex].image;
        priceSetup(gedungIndex);
        clone.GetComponent<Animator>().enabled = true;
        clone.GetComponent<Animator>().Play("SlideInRight");
        objekShop = clone;
    }

    //condition = false swipe left, true swipe right
    void indexSetup(bool condition)
    {
        if(condition)
        {
            gedungIndex+=1;
            if(gedungIndex>gedung.Count-1)
            {
                gedungIndex = 0;
            }
        }
        else
        {
            gedungIndex-=1;
            if(gedungIndex<0)
            {
                gedungIndex = gedung.Count-1;
            }
        }
    }

    void priceSetup(int index)
    {
        if(gedung[index].owned)
        {
            text.GetComponent<TextMeshProUGUI>().text = "Owned";
            buy.GetComponent<Button>().interactable = false;
            use.GetComponent<Button>().interactable = true;
        }
        else
        {
            text.GetComponent<TextMeshProUGUI>().text = "$"+gedung[index].price;
            buy.GetComponent<Button>().interactable = true;
            use.GetComponent<Button>().interactable = false;
        }
    }

    public void changeIndex()
    {
        gedungIndex = 0;
        objekShop.GetComponent<Image>().sprite = gedung[0].image;
        priceSetup(0);
    }

    // fungsi beli item
    public void buyItem()
    {
        if(gedung[gedungIndex].price <= playerData.money)
        {
            playerData.money = playerData.money - gedung[gedungIndex].price;
            int index = playerData.unlockableBuilding.Length;
            int[] newData = new int[index+1];
            int itter = 0;
            foreach(int x in playerData.unlockableBuilding)
            {
                newData[itter] = x;
                itter++;
            }
            newData[newData.Length-1] = gedungIndex;
            playerData.unlockableBuilding = newData;
            money.GetComponent<TextMeshProUGUI>().text = "$" + playerData.money;
            gedung[gedungIndex].owned = true;
            text.GetComponent<TextMeshProUGUI>().text = "Owned";
            buy.GetComponent<Button>().interactable = false;
            use.GetComponent<Button>().interactable = true;
            playerData.SavePlayer();
        }
        else
        {
            Debug.Log("money doesnt enough");
        }
        
    }

    public void useItem()
    {
        PlayerPrefs.SetInt("UsedItem", gedungIndex);
        PlayerPrefs.Save();
        gedungImage.GetComponent<SpriteRenderer>().sprite = gedung[gedungIndex].image;
        gedungImage2.GetComponent<SpriteRenderer>().sprite = gedung[gedungIndex].image2;
    }
    
}
