using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    private Transform player;
    public bool close = false;
    public float distance = 20f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < distance)
        {
            close = true;
        }
        else
            close = false;

    }
    
}
