using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed = 4f;
    public int HP = 1;

    private ParticleSystem smokes;
    private bool dead = false;
    private Transform frontCheck;
   

    void Awake()
    {
        frontCheck = transform.Find("frontCheck").transform;
        smokes = GetComponent<ParticleSystem>();

    }

    void OnCollisionEnter2D(Collision2D c){

        if (c.gameObject.tag == "ground")
            Flip();
}

    void FixedUpdate()
    {

        //sets enemy velocity to moveSpeed in the x axis

        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);

        foreach (Collider2D c in frontHits)
        {
            if (c.tag == "ground")
            {
                Flip();
                break;
            }
            if (c.tag == "deathBox")
            {
                Death();
                break;
            }

        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (HP <= 0 && !dead)
            Death();
    }

    public void Hurt()
    {
        HP--;
    }

    void Death()
    {
        smokes.Play();


        SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();
        //disable all of the sprite renderers
        foreach (SpriteRenderer s in otherRenderers)
        {
            s.enabled = false;
        }

        dead = true;

        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;

        }
    }

    public void Flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
}
