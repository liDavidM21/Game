using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyarrow : MonoBehaviour
{
    public float speed = 10;
    private float angle;
    private Rigidbody2D rigid;
    private static Vector3 direction;
    Vector3 playerpos;
    public GameObject total_damag; //I create a reference refering to all enemies, so i can deduct health from there;
    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.Find("character_0").transform.position;
        direction = playerpos - transform.position;
        rigid = GetComponent<Rigidbody2D>();
        total_damag = GameObject.FindWithTag("enemy");
        playerpos.z = -1;
        float angle = AngleBetweenTwoPoints(transform.position, playerpos);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.Rotate(new Vector3(0, 0, -90));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("easyenemy");
        foreach(GameObject i in enemies)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), i.GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        rigid.MovePosition(transform.position + (direction * 0.09f));
    }   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player_health.damaged += 5;
            total_damag.GetComponent<Total_damag>().hit = true;
        }
        Destroy(this.gameObject);
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
