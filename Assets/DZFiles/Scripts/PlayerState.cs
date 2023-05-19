using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Obstacle"))
        {
            gameManager.Respawn(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Obstacle"))
        {
            gameManager.Respawn(this.gameObject);
        }
    }
}
