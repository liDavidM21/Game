using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyarrow : MonoBehaviour
{
    public float speed = 10;
    private float angle;
    private Rigidbody2D rigid;
    public Vector3 direction = Vector3.zero;
    Vector3 playerpos;
    public GameObject total_damag; //I create a reference refering to all enemies, so i can deduct health from there;
    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.Find("character_0").transform.position;
        if (direction == Vector3.zero)
        {
            direction = (playerpos - transform.position).normalized;
        }
        rigid = GetComponent<Rigidbody2D>();
        total_damag = GameObject.FindWithTag("enemy");
        playerpos.z = -1;
        float angle = AngleBetweenTwoPoints(transform.position, playerpos);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.Rotate(new Vector3(0, 0, -90));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("easyenemy");
        foreach(GameObject i in enemies)
        {
            Physics2D.IgnoreCollision(i.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    void set_direction(float x, float y, float z)
    {
        direction.x = x;
        direction.y = y;
        direction.z = z;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(direction);
        rigid.MovePosition(transform.position + (direction * 0.09f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string col_obj = collision.gameObject.tag;
        if (col_obj == "Player")
        {
            player_health.damaged += 5;
            total_damag.GetComponent<Total_damag>().hit = true;
        }
        if (col_obj != "enemy_arrow")
        {
            Destroy(this.gameObject);
        }
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
