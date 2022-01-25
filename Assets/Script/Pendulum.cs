using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;
    public GameObject inisiasi;
    public GameObject boxPrefab;
    public GameObject pressScreen;
   
    public int i;
    bool pressed;
    bool movingClockwise;
    bool ableToPress;
    GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movingClockwise = true;
        ableToPress = false;
        pressed = false;
        i = 0;
        StartCoroutine(Inisiasi());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(ableToPress)
        {      
            if(Input.GetKeyDown(KeyCode.Space) || pressed)
            {          
                pressed = false;
                ableToPress = false;
                StartCoroutine(waiting());
                
                //Inisiasi();
            }
        }
        

        
        
    }

    public void ChangeDirection()
    {
        if(transform.rotation.z > rightAngle){
            movingClockwise = false;
        }
        if(transform.rotation.z < leftAngle) {
            movingClockwise = true;
        }
    }

    public void Move()
    {
        ChangeDirection();
        if(movingClockwise) {
            rb2d.angularVelocity = moveSpeed;
        }
        else{
            rb2d.angularVelocity = -1*moveSpeed;
        }
    }

    IEnumerator Inisiasi(){        
        
        clone = Instantiate(boxPrefab, inisiasi.transform.position, Quaternion.identity);
        clone.transform.parent = inisiasi.transform;
        clone.GetComponent<Box>().ableToPress = false;
        i++;
        clone.name = "Box"+i;
        HingeJoint2D cloneHinge;
        cloneHinge = clone.GetComponent<HingeJoint2D>();
        cloneHinge.enabled = true;
        cloneHinge.connectedBody = rb2d;
        clone.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        ableToPress = true;
        clone.GetComponent<Collider2D>().enabled = true;
        clone.GetComponent<Box>().ableToPress = true;  
        pressScreen.GetComponent<Button>().interactable = true;
    }

    IEnumerator waiting()
    {
         yield return new WaitForSeconds(0.5f);
         StartCoroutine(Inisiasi());
    }

    public void screenButton()
    {
        pressed = true;
        pressScreen.GetComponent<Button>().interactable = false;
        clone.GetComponent<Box>().screenButton();
    }
    

}
