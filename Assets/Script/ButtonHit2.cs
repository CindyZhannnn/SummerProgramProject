using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit2 : MonoBehaviour
{

    public DetectHIt detectH;
    public GameObject nextButton;
    public Animator button;
    public Sprite press;
    public Sprite unpress;
    public SpriteRenderer b;
    public Collider2D cn;

    void Start()
    {
        b = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.tag == "Player" && gameObject.GetComponent<Collider2D>() == cn)
        {
            detectH.turnButtonOn(nextButton);
            print(detectH.objectHit);
            button.SetBool("IsPress", true);
            //StartCoroutine(ChangetoUnpress());

            //Destroy(gameObject);

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
            // StartCoroutine(Changetopress());
        }


    }
    /*
    public System.Collections.IEnumerator ChangetoUnpress()
    {
        yield return new WaitForSeconds(1);
        b.sprite = unpress;
    }
    public System.Collections.IEnumerator Changetopress()
    {
        yield return new WaitForSeconds(1);
        b.sprite = press;
    }*/


}
