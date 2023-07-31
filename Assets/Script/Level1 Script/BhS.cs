using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhS : MonoBehaviour
{
    // Start is called before the first frame update
    public DetectHIt detectH;
    public GameObject nextButton;
    public Animator button;
    public Collider2D sto;

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
            detectH.turnButtonOn(nextButton);
            print(detectH.objectHit);
            button.SetBool("IsPress", true);
            sto.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D cd)
    {
        print("leaving");
        if (nextButton.tag == "Button3" && cd.tag == "Player")
        {
            print("destroyed all");
            detectH.destroyAllGameObj();
        }
        else if (cd.tag == "Player")
        {
            detectH.turnButtonOff(nextButton);
            button.SetBool("IsPress", false);
            sto.enabled = true;


        }


    }


}

