using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Collider2D wall;
    // Start is called before the first frame update
    void Start()
    {
        wall.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
