using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_increase : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigid;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            player_info.num_of_keys += 1;
        }
    }
}
