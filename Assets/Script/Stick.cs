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
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
            Collider2D[] all = Physics2D.OverlapCircleAll(this.transform.position, 0.5f,saltLayer);
            print(all.Length);
            if(all.Length != 0)
            {
                for(int i =0; i < all.Length; i++)
                {
                    all[i].enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < all.Length; i++)
                {
                    all[i].enabled = true;
                }
            }
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
