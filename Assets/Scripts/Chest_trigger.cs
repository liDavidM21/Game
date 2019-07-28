using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag == "Player");
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("collided", true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            animator.SetBool("collided", false);
        }
    }
}
