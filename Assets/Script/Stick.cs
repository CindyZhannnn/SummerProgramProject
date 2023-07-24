using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public Transform playerTransform;
    private bool isColliding = false;
    private bool isAttachedToPlayer = false;
    public int count;
    public Collider2D stickCollider;
    public Animator seed;



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (isColliding && count %2 ==1 )
            {
                seed.SetBool("pickUp", true);
                transform.SetParent(playerTransform);
            }
            else
            {
                seed.SetBool("pickUp", false);
                transform.SetParent(null);

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
