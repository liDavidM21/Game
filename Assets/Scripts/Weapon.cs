using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float fire_rate;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.transform.position;
    }

    // Update is called once per frame
    public void fire()
    {
        if (Time.time > time)
        {
            GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            time = Time.time + fire_rate;
        }
        
    }
}
