using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.enemy = this.GetComponentInParent<Enemy>();
    }    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.CompareTo("player") == 0)
        {
            enemy.attackPlayer = true;
            enemy.rb.velocity = new Vector2(0,0);
            this.GetComponentInParent<Animator>().SetTrigger("Attack");
            other.GetComponent<CharacterController2D>().ApplyDamage(2f, other.transform.position);
            Invoke("finishAttack", 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.CompareTo("player") == 0)
        {
            finishAttack();
        }
    }

    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.CompareTo("player") == 0 && !enemy.attackPlayer)
        {
            enemy.attackPlayer = true;
            enemy.rb.velocity = new Vector2(0,0);
            this.GetComponentInParent<Animator>().SetTrigger("Attack");
            other.GetComponent<CharacterController2D>().ApplyDamage(2f, other.transform.position);
            Invoke("finishAttack", 0.5f);
        }
        
    }

    private void finishAttack(){
            this.GetComponentInParent<Animator>().SetBool("Attack", false);
            enemy.attackPlayer = false;
    }
}
