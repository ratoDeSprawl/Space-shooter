using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private int healthPoints = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Shoot"))
        {
            healthPoints--;

            Destroy(other.gameObject);

            if (healthPoints <= 0)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            
        }
    }
}
