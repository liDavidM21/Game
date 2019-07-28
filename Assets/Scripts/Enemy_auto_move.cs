using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_auto_move : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;
    private Vector3 change;
    private Vector3 player_pos;
    public bool is_hit;
    public int damage;
    public int prev_attack = 0;
    public bool attacked = false;
    public bool first_attack = true;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacked)
        {
            prev_attack += 1;
        }
        else
        {
            prev_attack = 0;
        }
        if (prev_attack == 48)
        {
            attacked = false;
            prev_attack = 0;
        }
        rigid.freezeRotation = true;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && able_to_attack())
        {
            is_hit = true;
            attacked = true;
            damage = 2;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            is_hit = false;
        }
    }
    private bool able_to_attack()
    {
        if (first_attack)
        {
            first_attack = false;
            return true;
        }
        return !attacked;
    }
}
