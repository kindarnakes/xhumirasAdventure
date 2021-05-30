using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.tag.CompareTo("Player") == 0)
        {
            dataConserved.DATA.lifePotions += 1;
            Destroy(gameObject);
        }
    }
}
