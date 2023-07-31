using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{

    // Start is called before the first frame update
    public Animator player;
    public Gamem gm;
    public GameObject dead;
    public bool isPress;
    void Start()
    {
        isPress = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(isPress);
    }

    void OnTriggerEnter2D(Collider2D cn)
    {

        if(cn.tag == "Player")
        {
            gm.Playerdead(cn.gameObject);

        }
    }


}
