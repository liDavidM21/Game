using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flask_hp : MonoBehaviour
{
    public static bool healed = false;
    // Start is called before the first frame update
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
            if (player_health.damaged - 20 <= 0)
            {
                player_health.damaged = 0;
            }
            else
            {
                player_health.damaged -= 20;
            }
            healed = true;
            Destroy(this.gameObject);
        }
    }
}
