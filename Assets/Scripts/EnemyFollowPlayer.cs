using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float healthStart = 200;
    public float health;
    [Header("Unity Stuff")]
    public Image healthBar;
    public float moveSpeed = 2f;
    public float damge = 10f;

    private Rigidbody2D rigidbody;

    private void Start() {
        health = healthStart;
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
        direction.Normalize();
        Vector2 movement = direction;
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamge(float damge)
    {
        health -= damge;
        healthBar.fillAmount = health/healthStart;
        if( health <= 0 ) {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if( other.gameObject.CompareTag("Player") ) {
            other.gameObject.GetComponent<Player>().TakeDamge(damge);
        }
    }
}
