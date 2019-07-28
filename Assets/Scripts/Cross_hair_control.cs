using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross_hair_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = -1;
        gameObject.transform.position = pos;
    }
}
