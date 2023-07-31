using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;

public class Gamem : MonoBehaviour
{
    public Dictionary<GameObject, bool> players = new Dictionary<GameObject, bool>();
    public ArrayList playerGameObjects = new ArrayList();
    public int countNum ;
    public GameObject SplitAni;
    public Enemy en;
    public Animator player;
    public GameObject dead;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject playerObject in playerObjects)
        {
            if (!players.ContainsKey(playerObject))
            {
                playerGameObjects.Add(playerObject);
                countNum++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(players.Count);
        if(Input.GetKeyDown("q"))
        {
            SwitchBetweenPlayer();
        }
    }

    public void SwitchBetweenPlayer()
    {
        
        if (countNum >= playerGameObjects.Count)
        {
            countNum = countNum - playerGameObjects.Count;
        }
        print("current count: " + countNum);
        print("num of obj: " + playerGameObjects.Count);
        if (countNum == 0 )
        {
            GameObject previousPlayerObject = (GameObject)playerGameObjects[playerGameObjects.Count -1];
            previousPlayerObject.tag = "PlayerSub";
            PlayerMove previousScript = previousPlayerObject.GetComponent<PlayerMove>();
            previousScript.GotoSleep();
            previousScript.enabled = false;
            
        }
        else 
        {
            GameObject previousPlayerObject = (GameObject)playerGameObjects[countNum - 1];
            PlayerMove previousScript = previousPlayerObject.GetComponent<PlayerMove>();
            previousPlayerObject.tag = "PlayerSub";
            previousScript.GotoSleep();
            previousScript.enabled = false;
        }

        GameObject currentPlayerObject = (GameObject)playerGameObjects[countNum];
        PlayerMove currentScript = currentPlayerObject.GetComponent<PlayerMove>();
        currentPlayerObject.tag="Player";
     

        if (currentScript != null)
        {
            currentScript.enabled = true;
            currentScript.WakeUp();
        }



        //print("num of obj: " + playerGameObjects.Count);
        countNum++;

        //print(players[currentPlayerObject]);
    }

  public void haveNewObj(GameObject gameobj)
    {
        PlayerMove previousScript = gameobj.GetComponent<PlayerMove>();
        previousScript.GotoSleep();
        previousScript.enabled = false;
    }

 public void PlaySplitAni()
 {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Transform playerTransform = playerObject.transform;
        Transform splitAni = playerTransform.GetChild(0);
        splitAni.gameObject.SetActive(true);

 }

public void Playerdead(GameObject p)
    {
        if (playerGameObjects.Count > 1)
        {
            player = p.GetComponent<Animator>();
            player.SetBool("IsDead", true);
            PlayerMove pm =p.GetComponent<PlayerMove>();
            p.tag = "PlayerSub";
            int indexToRemove = playerGameObjects.IndexOf(p);
            SwitchBetweenPlayer();
            playerGameObjects.Remove(p);
            //print("after remove" + gm.playerGameObjects.Count);
            StartCoroutine(setScriptFalse2(pm));
        }
        else
        {
            player = p.GetComponent<Animator>();
            player.SetBool("IsDead", true);
            p.tag = "PlayerSub";
            dead.SetActive(true);
            PlayerMove pm = p.GetComponent<PlayerMove>();
            StartCoroutine(setDeadTrue());
            StartCoroutine(setScriptFalse(pm));
        }
    }
    IEnumerator setScriptFalse(PlayerMove pm)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < pm.transform.childCount; i++)
        {
            Transform child = pm.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
        pm.enabled = false;
        print("turned false");
    }
    IEnumerator setDeadTrue()
    {
        yield return new WaitForSeconds(1f);
        dead.SetActive(true);
    }
    IEnumerator setScriptFalse2(PlayerMove pm)
    {
        yield return new WaitForSeconds(0.5f);

        if (countNum >= playerGameObjects.Count)
        {
            countNum = countNum - playerGameObjects.Count;
            print("count: " + countNum);
            print("playercount" + playerGameObjects.Count);

        }
        for (int i = 0; i < pm.transform.childCount; i++)
        {
            Transform child = pm.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
        pm.enabled = false;
        print("turned false");
    }
}
