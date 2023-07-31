using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt : MonoBehaviour
{
    // Start is called before the first frame update
    public Gamem gm;
    public GameObject dead;
    public GameObject button;
    public Collider2D salt;
    public bool isDeadly;
    public Animator player;
    void Start()
    {
        salt = GetComponent<Collider2D>();
        isDeadly = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

                gm.Playerdead(collision.gameObject);

        }
        else if(collision.CompareTag("Stick") )
        {
            //isDeadly = false;

        }
        else if(collision.CompareTag("Bug"))
        {
            button.SetActive(true);
            Destroy(collision.gameObject);


        }
    }
    private IEnumerator HideSpriteRendererWithDelay(GameObject gameObjectToHide)
    {
        yield return new WaitForSeconds(1f);
        PlayerMove pm = gameObjectToHide.GetComponent<PlayerMove>();
        pm.enabled = false;

        for (int i = 0; i < gameObjectToHide.transform.childCount; i++)
        {
            Transform child = gameObjectToHide.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
    }


    public void OnTriggerExit2D(Collider2D cn)
    {
        if(cn.tag == "Stick")
        {
            isDeadly = true;
        }
    }


}
