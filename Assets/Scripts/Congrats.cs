using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Congrats : MonoBehaviour {

    private Text goodJob;
    private House home;

    void Awake()
    {
        goodJob = GetComponent<Text>();
        home = GameObject.FindGameObjectWithTag("Finish").GetComponent<House>();
    }

    void Update()
    {
        if (home.close)
        {
            if (!goodJob.enabled)
                goodJob.enabled = true;
        }
    }
}
