using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float startHealth = 100f;
    private float health;
    public GameObject deadEffect;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamge(float damge)
    {
        health -= damge;
        healthBar.fillAmount = health/startHealth;
        if( health <= 0 ) {
            Die();
        }
    }

    public void TakeHealth(float healthIns)
    {
        Debug.Log(healthIns);
        health += healthIns;
        if( health > startHealth ) {
            health = startHealth;
        }
        healthBar.fillAmount = health/startHealth;
    }

    private void Die()
    {
        GameObject effect = Instantiate(deadEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        // gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(effect, .4f);
    }
}
