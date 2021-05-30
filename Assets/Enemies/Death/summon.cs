using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summon : MonoBehaviour
{
    public Vector2 direction = new Vector2();
    public bool hasHit = false;
    public float speed = 10f;
    public Rigidbody2D rigidbody2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 8f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit)
            GetComponent<Rigidbody2D>().velocity = direction * speed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            collision.GetComponent<CharacterController2D>().ApplyDamage(1f, collision.transform.position);
            Destroy(gameObject);
        }

    }
}
