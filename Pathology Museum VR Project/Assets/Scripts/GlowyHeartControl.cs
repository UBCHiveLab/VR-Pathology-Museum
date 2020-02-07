using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowyHeartControl : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.K))
        //{
          //  SelfDestruct();
        //}
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("StoppyHeart"))
        {
            Destroy(this.gameObject);
        }
    }

    public void SelfDestruct()
    {
        animator.SetTrigger("StopThis");
    }
}
