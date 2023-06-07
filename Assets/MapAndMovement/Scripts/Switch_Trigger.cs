using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Trigger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject gate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTrigger
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name.Equals("Player 1")){
            gate.GetComponent<SpriteRenderer>().enabled = false;
            gate.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(other.gameObject.name.Equals("Player 2")){
            gate.GetComponent<SpriteRenderer>().enabled = false;
            gate.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    //On Exit
    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.name.Equals("Player 1")){
            gate.GetComponent<SpriteRenderer>().enabled = true;
            gate.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if(other.gameObject.name.Equals("Player 2")){
            gate.GetComponent<SpriteRenderer>().enabled = true;
            gate.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
