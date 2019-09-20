using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject give_weapon;
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
        GameObject current_obj = collision.gameObject;
        if (current_obj.tag == "Player")
        {
            if (!current_obj.GetComponent<Player_move>().weapons.Contains(current_obj))
            {
                current_obj.GetComponent<Player_move>().give_weapon(give_weapon);
                animator.SetBool("collided", true);
            }

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
