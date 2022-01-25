using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    GameObject laser, target, gameInitial;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Box")
        {
            laser.transform.position = new Vector3(laser.transform.position.x, laser.transform.position.y-3.73f, laser.transform.position.z);
            target.transform.position = new Vector3(0, target.transform.position.y-3.73f, -10); 
            gameInitial.GetComponent<GameOver>().life -= 1;
//            Debug.Log(gameInitial.GetComponent<GameOver>().life);
        }
    }

    

    
}
