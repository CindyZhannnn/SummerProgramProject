using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public Transform playerTransform;
    private bool isColliding = false;
    //private bool isAttachedToPlayer = false;
    public int count;
    public Animator seed;
    public LayerMask saltLayer;



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (isColliding)
            {
                seed.SetBool("pickUp", true);
                transform.SetParent(playerTransform);
            }
        }
        else
        {
            seed.SetBool("pickUp", false);
            transform.SetParent(null);

        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Collider2D[] all = Physics2D.OverlapCircleAll(this.transform.position, 2,saltLayer);
            print(all.Length);
        }
    }

    public void OnTriggerEnter2D(Collider2D cn)
    {
        if(cn.tag == "GrabCd")
        {
            isColliding = true;
        }
    }
    public void OnTriggerExit2D(Collider2D cn)
    {
        if (cn.CompareTag("GrabCd"))
        {
            isColliding = false;

        }

    }
}
