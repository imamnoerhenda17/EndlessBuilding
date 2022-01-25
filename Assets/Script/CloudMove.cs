using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject initialize, start, end, clone;

    float step;
    bool lewat;
   
    void Start()
    {
        lewat = false;
        initialize = GameObject.Find("InitiatePointCloud");
        end = GameObject.Find("EndPoint");
        start = GameObject.Find("StartPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        step = 0.5f * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, end.transform.position, step);
        if(!lewat)
        {
            if(this.transform.position.x>initialize.transform.position.x)
            {
                Instantiate(clone, start.transform.position, Quaternion.identity);
                lewat = true;
            }
        }

        if(this.transform.position.x == end.transform.position.x)
        {
            Destroy(this.gameObject);
        }
        
    }
}
