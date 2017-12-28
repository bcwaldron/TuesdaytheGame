using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float repeatDamagePeriod = 2f;
    public float hurtForce = 10f;
    public float damageAmount = 10f;
    public bool dead = false;

    private SpriteRenderer healthBar;
    private float lastHitTime;
    private Vector3 healthScale;
    private PlayerControl playerCtrl;
    private Animator anim;

    void Awake()
    {
        playerCtrl = GetComponent<PlayerControl>();
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthScale = healthBar.transform.localScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if enemy
        if (col.gameObject.tag == "Enemy")
        {
            //if time exceeds time of last hit + damperiod
            if (Time.time > lastHitTime + repeatDamagePeriod)
            {
                //if player still has health
                if (health > 0f)
                {
                    TakeDamage(col.transform);
                    lastHitTime = Time.time;
                }
                    //player has no health/ ie Dead
                else
                {
                    //triger "die" animation
                    anim.SetTrigger("Die");

                    dead = true;

                      //set all components to trigger
                      Collider2D[] cols = GetComponents<Collider2D>();
                      foreach (Collider2D c in cols)
                      {
                          c.isTrigger = true;
                      }

                      SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
                      foreach (SpriteRenderer s in spr)
                      {
                          s.sortingLayerName = "UI";
                      }

                      //disable player control
                      GetComponent<PlayerControl>().enabled = false;

                      //disable barker
                      GetComponentInChildren<Barker>().enabled = false;
                    
                }
            }
        }

        //if fell below level
        if (col.gameObject.tag == "deathBox")
        {
            dead = true;
            GetComponent<PlayerControl>().enabled = false;
            GetComponentInChildren<Barker>().enabled = false;
        }
    }

    void TakeDamage(Transform enemy)
    {
        //player can't jump
        playerCtrl.jump = false;

        //create a vector from enemy to player with upwards momentum
        Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;

        //apply force to the player and multiply by hurtforce
        GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);

        //reduce health
        health -= damageAmount;

        //update healthbar visual
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
        //set color to proportion between green and red
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

        //fill healthbar proportional to health
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
    }
}