using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit2 : MonoBehaviour
{

    public Animator button;
    public Animator door;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.tag == "Player")
        {
            button.SetBool("IsPress", true);
            door.SetBool("DoorOpen", true);
        }
    }
    void OnTriggerExit2D(Collider2D cd)
    {

         if (cd.tag == "Player")
        {
            button.SetBool("IsPress", false);

        }


    }

}
