using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;
    private Vector3 change;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector2.zero;
        rigid.freezeRotation = true;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero){
            Character_move();
            animator.SetFloat("MOVE_X", change.x);
            animator.SetFloat("MOVE_Y", change.y);
            animator.SetBool("IS_WALKING", true);
        }
        else
        {
            animator.SetBool("IS_WALKING", false);
        }
    }

    //Script to make the character move
    void Character_move()
    {
        rigid.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
