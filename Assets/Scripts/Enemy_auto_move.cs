using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_auto_move : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;
    private Vector3 change;
    private Vector3 player_pos;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player_pos = GameObject.Find("character_0").transform.position;
        if ((player_pos-transform.position).sqrMagnitude <= 40)
        {
            change = (player_pos - transform.position).normalized;
            enemy_move();
        }
    }
    
    //Enemy moving to attack player
    void enemy_move()
    {
        rigid.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
