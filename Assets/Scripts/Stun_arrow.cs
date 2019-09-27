using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun_arrow : MonoBehaviour
{
    public float speed = 0.03f;
    private float angle;
    private Rigidbody2D rigid;
    public Vector3 direction = Vector3.zero;
    Vector3 playerpos;
    public GameObject total_damag; //I create a reference refering to all enemies, so i can deduct health from there;
    // Start is called before the first frame update
    void Awake()
    {
        playerpos = GameObject.Find("character_0").transform.position;
        direction = (playerpos - transform.position).normalized;
        rigid = GetComponent<Rigidbody2D>();
        total_damag = GameObject.FindWithTag("enemy");
        playerpos.z = -1;
        float angle = AngleBetweenTwoPoints(transform.position, playerpos);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.Rotate(new Vector3(0, 0, -90));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("easyenemy");
        foreach (GameObject i in enemies)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), i.GetComponent<Collider2D>());
        }
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("stunning_enemy").GetComponent<Collider2D>());
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string col = collision.gameObject.tag;
        if (col == "Player")
        {
            Player_move.stunned = true;
            Destroy(this.gameObject);

        }
        if (col == "Walls" || col == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
