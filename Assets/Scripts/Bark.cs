using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().Hurt();

            Destroy(gameObject);
        }

        else if (col.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
