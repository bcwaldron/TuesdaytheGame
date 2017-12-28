using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barker : MonoBehaviour {

    public Rigidbody2D bark;
    public float speed = 20f;

    private PlayerControl playerCtrl;
    private Animator anim;

    void Awake()
    {
        anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = transform.root.GetComponent<PlayerControl>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            GetComponent<AudioSource>().Play();

            if (playerCtrl.facingRight)
            {
               Rigidbody2D barkInstance = Instantiate(bark, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
               barkInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                Rigidbody2D barkInstance = Instantiate(bark, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                barkInstance.velocity = new Vector2(-speed, 0);
            }

        }
    }
}