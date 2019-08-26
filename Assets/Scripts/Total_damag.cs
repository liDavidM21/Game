using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Total_damag : MonoBehaviour
{
    public float damage = 0;
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int child_num = gameObject.transform.childCount;
        for(int i = 0; i < child_num; i++)
        {
            GameObject tmp = gameObject.transform.GetChild(i).gameObject;
            if (tmp.GetComponent<Enemy_auto_move>().is_hit)
            {
                hit = true;
                damage += tmp.GetComponent<Enemy_auto_move>().damage;
                tmp.GetComponent<Enemy_auto_move>().damage = 0;
                tmp.GetComponent<Enemy_auto_move>().is_hit = false;
            }
        }
    }
}
