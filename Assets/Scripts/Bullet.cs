using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D other) {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        if( other.gameObject.CompareTag("Enermy") ) {
            Destroy(other.gameObject);
        }
        Destroy(effect, .4f);
        Destroy(gameObject);
    }
}
