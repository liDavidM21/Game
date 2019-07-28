using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Vector3 mouse_pos;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse_pos.z = -1;
        float angle = AngleBetweenTwoPoints(transform.position, mouse_pos);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.Rotate(new Vector3(0, 0, -90));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * speed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
