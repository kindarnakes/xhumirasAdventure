using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heallife : MonoBehaviour
{
    // Start is called before the first frame update

    public float lifeToHeal = 1f;
    void Start()
    {
        Destroy(this.gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.CompareTo("Player") == 0)
        {
            other.GetComponent<CharacterController2D>().heal(4f);
            Destroy(gameObject);
        }
    }
}
