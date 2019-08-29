using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class adjusthealth : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider sli;
    
    void Start()
    {
        sli = GetComponent<Slider>();
        if (SceneManager.GetActiveScene().name != "level0")
        {
            sli.value -= player_health.damaged;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
