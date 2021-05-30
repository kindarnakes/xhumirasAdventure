using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vendor : MonoBehaviour
{

    public GameObject text;
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
            text.SetActive(true);
            other.GetComponent<PlayerMovement>().shop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag.CompareTo("Player") == 0)
        {
            text.SetActive(false);
            other.GetComponent<PlayerMovement>().shop = false;
        }
    }

}
