using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private List<GameObject> player = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name.Equals("Player 1")){
            if(!player.Contains(other.gameObject)){
                player.Add(other.gameObject);
            }
        }
        else if(other.gameObject.name.Equals("Player 2")){
            if(!player.Contains(other.gameObject)){
                player.Add(other.gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(player.Count==2){
            //load new scene;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(player.Contains(other.gameObject)){
            player.Remove(other.gameObject);
        }
    }
}
