using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed;
    public float fire_rate;
    public GameObject bullet;
    private GameObject current_weapon;
    private Rigidbody2D rigid;
    private Vector3 change;
    private Animator animator;
    private Collider2D collide;
    private LinkedList<GameObject> weapons = new LinkedList<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        animator = GetComponent<Animator>();
        collide = GetComponent<Collider2D>();
        current_weapon = transform.GetChild(0).gameObject;
        weapons.AddFirst(current_weapon);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        rigid.freezeRotation = true;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero) {
            Character_move();
            animator.SetFloat("MOVE_X", change.x);
            animator.SetFloat("MOVE_Y", change.y);
            animator.SetBool("IS_WALKING", true);
        }
        else
        {
            animator.SetBool("IS_WALKING", false);
        }
        if (Shoot())
        {
            current_weapon.GetComponent<Weapon>().fire();

        }
        if (swap())
        {
            if(weapons.Find(current_weapon).Next != null)
            {
                swap_weapon(weapons.Find(current_weapon).Next.Value);
            }
            else
            {
                swap_weapon(weapons.First.Value);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            Debug.Log("hi");
        }
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector3(0, 0, 0);
    }
    //Script to make the character move 
    void Character_move()
    {
        rigid.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }
    bool Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            return true;
        }
        return false;
    }
    bool swap()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            return true;
        }
        return false;
    }
    void swap_weapon(GameObject new_weapon)
    {
        Destroy(current_weapon);
        Instantiate(new_weapon, transform.position, Quaternion.identity);
        current_weapon = new_weapon;
    }
}
