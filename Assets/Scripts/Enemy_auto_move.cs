using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_auto_move : MonoBehaviour
{
    public float speed = 0.03f;
    public GameObject ENEMYARROW;
    public enemyarrow arrows;
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
            if (enemy_health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void fire()
    {
        if (gameObject.transform.tag == "easyenemy")
        {
            GameObject.Instantiate(ENEMYARROW, transform.position, Quaternion.identity);
        }
        else if (gameObject.transform.tag == "shade_attack_enemy")
        {
            Vector3 inst_diretion = (GameObject.Find("character_0").transform.position - gameObject.transform.position).normalized;
            Vector3 tmp = inst_diretion;
            for (int i = 0; i < 9; i++)
            {
                //arrows.AddLast();
                GameObject arrow = GameObject.Instantiate(ENEMYARROW, transform.position, Quaternion.identity);
                if (i < 4)
                {
                    if (i != 0)
                    {
                        inst_diretion.x = Mathf.Cos(Mathf.PI / 9) * inst_diretion.x - Mathf.Sin(Mathf.PI / 9) * inst_diretion.y;
                        inst_diretion.y = Mathf.Sin(Mathf.PI / 9) * inst_diretion.x + Mathf.Cos(Mathf.PI / 9) * inst_diretion.y;
                    }
                }
                else
                {
                    if (i == 4)
                    {
                        inst_diretion = (GameObject.Find("character_0").transform.position - gameObject.transform.position).normalized;
                    }
                    inst_diretion.x = Mathf.Cos(-Mathf.PI / 9) * inst_diretion.x - Mathf.Sin(-Mathf.PI / 9) * inst_diretion.y;
                    inst_diretion.y = Mathf.Sin(-Mathf.PI / 9) * inst_diretion.x + Mathf.Cos(-Mathf.PI / 9) * inst_diretion.y;
                }
                Vector3 setter;
                setter.x = inst_diretion.x;
                setter.y = inst_diretion.y;
                setter.z = -1;
                setter = setter.normalized;
                arrow.GetComponent<enemyarrow>().direction = setter;
            }
            //int p = 0;
            //foreach(GameObject tmp in arrows)
            //{
            //    Debug.Log("hi");
            //    if (tmp != null)
            //    {
            //        inst_diretion.x = Mathf.Cos((p + 1) * 20) * inst_diretion.x - Mathf.Sin((p + 1) * 20) * inst_diretion.y;
            //        inst_diretion.y = Mathf.Sin((p + 1) * 20) * inst_diretion.x - Mathf.Cos((p + 1) * 20) * inst_diretion.y;
            //        Vector3 setter;
            //        setter.x = inst_diretion.x;
            //        setter.y = inst_diretion.y;
            //        setter.z = -1;
            //        setter = setter.normalized;
            //        tmp.GetComponent<enemyarrow>().direction_setter(setter);
            //        p += 1;
            //    }
            //}
            //arrows = new LinkedList<GameObject>();
        }
    }   
}  