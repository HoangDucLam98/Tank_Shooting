using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;

    private Rigidbody2D rigidbody;

    private void Start() {
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
}
