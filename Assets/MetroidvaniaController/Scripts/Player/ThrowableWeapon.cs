using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableWeapon : MonoBehaviour
{
	public Vector2 direction;
	public bool hasHit = false;
	public float speed = 10f;

	public Vector2 CenterOfMass;
	public Rigidbody2D rigidbody2;

    // Start is called before the first frame update
    void Start()
    {

		rigidbody2.centerOfMass = CenterOfMass * (direction.x);
		Destroy(this.gameObject, 5);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if ( !hasHit)
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
			
		if (collision.gameObject.tag.CompareTo("Enemy") == 0)
		{
			collision.gameObject.SendMessage("ApplyDamage", dataConserved.DATA.damageRanged());
		}
		Destroy(gameObject);
		
	}
}
