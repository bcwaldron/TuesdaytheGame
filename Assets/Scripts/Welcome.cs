using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welcome : MonoBehaviour {

    private Text hello;

    void Awake()
    {
        hello = GetComponent<Text>();
        Destroy(hello, 3);
    }
}
