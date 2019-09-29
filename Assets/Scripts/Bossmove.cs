using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmove : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigid;
    private int speed = 5;
    private bool triggered = false;
    int frame_count = 0;
    private bool attack = false;
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rigid.freezeRotation = true;
        Vector3 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        danger_zone();
        if (triggered)
        {
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            }
            else
            {
                transform.localScale = new Vector3(-4.0f, 4.0f, 4.0f);
            }
            rigid.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            if ((GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).magnitude < 1.5 && !attack)
            {
                attack = true;
            }
            if (attack)
            {
                frame_count += 1;
                if (frame_count <= 30)
                {
                    animator.SetTrigger("Attack");   
                }
                else if (frame_count == 60)
                {
                    attack = false;
                    frame_count = 0;
                }
            }
        }
        if (health == 0)
        {
            animator.SetTrigger("Death");
        }
    }
    void danger_zone()
    {
        float norm = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).magnitude;
        if (norm <= 3)
        {
            triggered = true;
        }
    }
}
