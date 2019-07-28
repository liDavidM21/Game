using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour
{
    public Slider sli;
    // Start is called before the first frame update
    void Start()
    {
        sli = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy_hit = GameObject.FindWithTag("enemy");
        if (enemy_hit.GetComponent<Total_damag>().hit)
        {
            sli.value -= enemy_hit.GetComponent<Total_damag>().damage;
            enemy_hit.GetComponent<Total_damag>().hit = false;
            enemy_hit.GetComponent<Total_damag>().damage = 0;
        }
    }
}
