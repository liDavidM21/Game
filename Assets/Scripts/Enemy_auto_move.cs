using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_auto_move : MonoBehaviour
{
    public float speed = 0.03f;
    public GameObject ENEMYARROW;
    int firerate;
    private Rigidbody2D rigid;
    private Vector3 change;
    private Vector3 player_pos;
    public bool is_hit;
    public float damage;
    public int prev_attack = 0;
    public bool attacked = false;
    public bool chasing = false;
    public int enemy_health = 100;
    public bool first_attack = true;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.inertia = 0;
    }

    // Update is called once per frame
    void Update()
    {
        is_hit = false;
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
        if ((player_pos - transform.position).sqrMagnitude <= 40 || chasing)
        {
            change = (player_pos - transform.position).normalized;
            change.z = -1;
            chasing = true;
            enemy_move();
            firerate += 1;
            if (firerate == 60)
            {
                fire();
                firerate = 0;
            }
        }
        if (Mathf.Sqrt(Mathf.Pow((player_pos - transform.position).x,2) + Mathf.Pow((player_pos-transform.position).y, 2)) <= 1.415)
        {
            attacked = true;
            damage = 1;
            is_hit = true;
        }
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector3(0, 0, 0);
    }
    //Enemy moving to attack player
    void enemy_move()
    {
        rigid.MovePosition(transform.position + (change * speed));
    }
    
    //Destroy enemy if damaged by bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            enemy_health -= 20;
            if (enemy_health <= 0){
                Destroy(this.gameObject);
            }
        } 
    }
    private void fire()
    {
        GameObject.Instantiate(ENEMYARROW, transform.position, Quaternion.identity);
    }
}  