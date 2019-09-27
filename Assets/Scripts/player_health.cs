using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour
{
    public Slider sli;
    public static float damaged = 0;
    // Start is called before the first frame update
    void Start()
    {
        sli = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy_hit = GameObject.FindWithTag("enemy");
        if (enemy_hit.GetComponent<Total_damag>().hit || flask_hp.healed == true)
        {
            damaged += enemy_hit.GetComponent<Total_damag>().damage / 5;
            sli.value = 100-damaged;
            enemy_hit.GetComponent<Total_damag>().hit = false;
            enemy_hit.GetComponent<Total_damag>().damage = 0;
        }
    }
}
