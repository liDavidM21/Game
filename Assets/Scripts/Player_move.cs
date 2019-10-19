using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed;
    public int time_elapsed = 0;
    public float fire_rate;
    public LinkedList<GameObject> weapons = new LinkedList<GameObject>();
    private GameObject current_weapon;
    private Rigidbody2D rigid;
    private Vector3 change;
    private Animator animator;
    public static bool stunned = false;
    private Collider2D collide;
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
        if (!stunned)
        {
            change = Vector3.zero;
            rigid.freezeRotation = true;
            change.x = Input.GetAxisRaw("Horizontal");
            Debug.Log(change.x);
            change.y = Input.GetAxisRaw("Vertical");
            if (change != Vector3.zero)
            {
                Character_move();
                animator.SetFloat("MOVE_X", change.x);
                animator.SetFloat("MOVE_Y", change.y);
                animator.SetBool("IS_WALKING", true);
            }
            else
            {
                animator.SetBool("IS_WALKING", false);
            }
            if (swap())
            {
                if (weapons.Find(current_weapon).Next != null)
                {
                    swap_weapon(weapons.Find(current_weapon).Next.Value);
                }
                else
                {
                    swap_weapon(weapons.First.Value);
                }
            }
        }
        else
        {
            time_elapsed += 1;
            if (time_elapsed >= 40)
            {
                time_elapsed = 0;
                stunned = false;
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
        current_weapon.SetActive(false);
        new_weapon.SetActive(true);
        current_weapon = new_weapon;
    }
    public void give_weapon(GameObject new_weapon)
    {
        GameObject switched_weapon = Instantiate(new_weapon, transform.position, Quaternion.identity);
        switched_weapon.transform.SetParent(gameObject.transform);
        weapons.AddLast(switched_weapon);
        switched_weapon.SetActive(false);
    }
}
