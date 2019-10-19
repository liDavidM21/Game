using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_beam : Bullet
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        int layermask = 1 << 8;
        layermask = ~layermask;
        initial_position();
        RaycastHit2D rh2d;
        rh2d = Physics2D.Raycast(transform.position, -transform.up, Mathf.Infinity, layermask);
        LineRenderer line_renderer = gameObject.GetComponent<LineRenderer>();
        Debug.Log(rh2d.transform.name);
        line_renderer.SetPosition(0, transform.position);
        line_renderer.SetPosition(1, new Vector3(rh2d.point.x, rh2d.point.y, transform.position.z));
    }
}
