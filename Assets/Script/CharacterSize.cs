using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSize : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        player.transform.localScale = ScaleHolder.characterScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
