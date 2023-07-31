using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveManage : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator s1;
    public Animator s2;
    public Animator s3;
    public Animator s4;
    public bool isTurning; 

   void Start()
    {
        isTurning = true;
        StartCoroutine(SwitchObjects());
        
    }

    private System.Collections.IEnumerator SwitchObjects()
    {
        while (isTurning)
        {

            s1.SetBool("IsOn", true);
            s1.gameObject.GetComponent<Collider2D>().enabled = true;
            s2.SetBool("IsOn", false);
            s2.gameObject.GetComponent<Collider2D>().enabled = false;
            s3.SetBool("IsOn", false);
            s3.gameObject.GetComponent<Collider2D>().enabled = false;
            s4.SetBool("IsOn", true);
            s2.gameObject.GetComponent<Collider2D>().enabled = true;
            yield return new WaitForSeconds(3f);


            s1.SetBool("IsOn", false);
            s1.gameObject.GetComponent<Collider2D>().enabled = false;
            s2.SetBool("IsOn",true);
            s2.gameObject.GetComponent<Collider2D>().enabled = true;
            s3.SetBool("IsOn",true);
            s3.gameObject.GetComponent<Collider2D>().enabled = true;
            s4.SetBool("IsOn",false);
            s4.gameObject.GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(3f);


        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
