using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        this.enemy = this.GetComponentInParent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.CompareTo("player") == 0)
        {
            enemy.seePlayer = true;
            /*float playerX = other.transform.position.x;
            float posX = this.transform.position.x;
                if (enemy.facingRight && posX > playerX)
                {
                    enemy.Flip();
                }
                else if (!enemy.facingRight && posX < playerX)
                {
                    enemy.Flip();
                }*/
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.CompareTo("player") == 0)
        {
            enemy.seePlayer = false;
        }
    }


}
