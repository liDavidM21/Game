using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float fire_rate;
    public string type;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.transform.position;
    }
    private void Update()
    {
        if (Shoot())
        {
            if(type == "bullet")
            {
                fire_bullet();
            }
            else if(type == "laser")
            {
                fire_laser();
            }

        }
        else
        {
            if(type == "laser")
            {
                if(transform.childCount != 0)
                {
                    Destroy(transform.GetChild(0).gameObject);
                }

            }
        }
    }
    // Update is called once per frame
    public void fire_bullet()
    {
        if (Time.time > time)
        {
            GameObject.Instantiate(bullet, transform.position, Quaternion.identity, gameObject.transform);
            time = Time.time + fire_rate;
        }     
    }
    void fire_laser()
    {
        if (gameObject.transform.childCount == 0)
        {
            GameObject.Instantiate(bullet, transform.position, Quaternion.identity, gameObject.transform);
        }
    }
    bool Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            return true;
        }
        return false;
    }
}
