using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instaDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            collision.GetComponent<CharacterController2D>().ApplyDamage(10f, collision.transform.position);
        }
        else if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.ApplyDamage(10000f);
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            collision.GetComponent<CharacterController2D>().ApplyDamage(10f, collision.transform.position);
        }
        else if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.ApplyDamage(10000f);
            }
        }
    }
}
