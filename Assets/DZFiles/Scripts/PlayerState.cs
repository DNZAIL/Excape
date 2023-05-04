using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Obstacle"))
        {
            gameManager.Respawn(this.gameObject);
        }
    }
}
