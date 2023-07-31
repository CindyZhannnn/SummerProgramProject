using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float movementSpeed = 2f; // Speed at which the enemy moves towards the player
    public Gamem gm;
    public GameObject dead;
    public string playerTag = "Player";
    public Animator playerAni;
    public GameObject nextScene;

    private void Start()
    {
        
        GameObject playerObject = GameObject.FindWithTag(playerTag);
        player = playerObject.transform;
        playerAni = playerObject.GetComponent<Animator>();
        
    }
    public void findPlayerTag()
    {
        GameObject playerObject = GameObject.FindWithTag(playerTag);
        player = playerObject.transform;
        playerAni = playerObject.GetComponent<Animator>();

    }

    private void Update()
    {
        GameObject playerObject = GameObject.FindWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collider2D collider1 = GetComponent<Collider2D>();
            float size1 = collider1.bounds.size.magnitude;
            float size2 = other.bounds.size.magnitude;
            if (size1 < size2)
            {
                Destroy(gameObject);
                nextScene.SetActive(true);

            }
            else
            {

                gm.Playerdead(other.gameObject);
                
            }
            

            


            }
    }

    private IEnumerator HideSpriteRendererWithDelay(GameObject gameObjectToHide)
    {
        yield return new WaitForSeconds(2f);

        SpriteRenderer spriteRenderer = gameObjectToHide.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        for (int i = 0; i < gameObjectToHide.transform.childCount; i++)
        {
            Transform child = gameObjectToHide.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
    }






}
