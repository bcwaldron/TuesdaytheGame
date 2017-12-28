using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour {

	private PlayerHealth health;
    private Text deathText;

    void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        deathText = GetComponent<Text>();
    }

    void Update()
    {
        if (health.dead)
            deathText.enabled = true;
    }
}
