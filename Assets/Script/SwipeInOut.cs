using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInOut : MonoBehaviour
{
    [SerializeField]
    GameObject objekswipe;
    public Animator anim;
    bool done;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("SwipeOut"))
            {
                done = false;
                StartCoroutine(waitingForOut());
            }
        }
    }

    public void masuk()
    {
        done = false;
        objekswipe.SetActive(true);
        anim.Play("SwipeIn");
    }

    public void keluar()
    {
        anim.Play("SwipeOut");
        done = true;

    }

    IEnumerator waitingForOut()
    {
        yield return new WaitForSeconds(0.8f);
        objekswipe.SetActive(false);
    }


}
