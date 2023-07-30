using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveManage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
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

            s1.SetActive(true);
            s2.SetActive(false);
            s3.SetActive(false);
            s4.SetActive(false);
            yield return new WaitForSeconds(10f);


            s1.SetActive(false);
            s2.SetActive(true);
            s3.SetActive(false);
            s4.SetActive(false);
            yield return new WaitForSeconds(10f);


            s1.SetActive(false);
            s2.SetActive(false);
            s3.SetActive(true);
            s4.SetActive(false);
            yield return new WaitForSeconds(10f);

            s1.SetActive(false);
            s2.SetActive(false);
            s3.SetActive(false);
            s4.SetActive(true);
            yield return new WaitForSeconds(10f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
