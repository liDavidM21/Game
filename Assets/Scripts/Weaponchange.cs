using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponchange : MonoBehaviour
{
    public Sprite[] Weaponsprite;
    int count = 1;
    bool can_change;
    // Start is called before the first frame update
    private void Awake()
    {
        Weaponsprite = Resources.LoadAll<Sprite>("weapon_sheet");

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
            if (count == Weaponsprite.Length)
            {
                count = 0;
            }
            Current.sprite = Weaponsprite[count];
            count += 1;
            can_change = false;
        }
    }
}
