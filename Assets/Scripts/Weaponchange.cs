using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponchange : MonoBehaviour
{
    public static Sprite[] Weaponsprite;
    public static int count = 0;
    public static bool[] avaliable_weapns = new bool[16];
    bool can_change;    
    // Start is called before the first frame update
    private void Awake()
    {
        Weaponsprite = Resources.LoadAll<Sprite>("weapon_sheet");
        //at the beginning, only the first weapon is avaliable
        avaliable_weapns[0] = true;
        for (int i = 1; i < Weaponsprite.Length; i++)
        {
            avaliable_weapns[i] = false;
        }
    }
    void Start()
    {
    }   

    // Update is called once per frame  
    void Update()
    {
        SpriteRenderer Current = GetComponent<SpriteRenderer>();
        bool iskeydown = Input.GetKey(KeyCode.O);
        if (iskeydown)
        {
            can_change = true;
        }
        if (!iskeydown && can_change)
        {
            count = get_next_weapon(count);
            Current.sprite = Weaponsprite[count];
            can_change = false;
        }
    }
    private int get_next_weapon(int count)
    {
        if (count == 15)
        {
            return 0;
        }
        for (int i = count + 1; i < 16; i++)
        {
            if (avaliable_weapns[i] == true)
            {
                return i;
            }
        }
        return 0;
    }
}
