using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public GameObject target;
    
    
    // Start is called before the first frame update
    float distance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnTriggerStay2D(Collider2D other)
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y+3.73f, transform.position.z);
        target.transform.position = new Vector3(0, target.transform.position.y+3.73f, -10); 
    }
}
