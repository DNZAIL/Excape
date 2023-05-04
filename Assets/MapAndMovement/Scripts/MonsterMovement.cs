using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] 
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private float speed;

    private Vector2 move;

    private Rigidbody2D monsterMove;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        monsterMove = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        checkForDistance();
        Vector3 diret=(target.position - transform.position).normalized;
        move=diret;
        monsterMove.velocity=new Vector2(move.x,move.y)*speed;
    }

    private void checkForDistance(){
        Vector2 current=transform.position;
        Vector2 targ1=player1.transform.position;
        Vector2 targ2=player2.transform.position;
        float dist1=Vector2.Distance(current, targ1);
        float dist2=Vector2.Distance(current, targ2);
        if(dist1<=dist2){
            target = player1.transform;
        }
        else{
            target = player2.transform;
        }
    }
}
