using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumObject : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = 5f * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, step);
    }
}
