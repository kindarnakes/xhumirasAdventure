using System;
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float life = 10;
    private bool isPlat;
    private bool isObstacle;
    private Transform fallCheck;
    private Transform wallCheck;
    public LayerMask turnLayerMask;
    public Rigidbody2D rb;

    private bool canFlip = true;

    public bool facingRight = true;

    public float speed = 5f;

    public bool isInvincible = false;
    private bool isHitted = false;
    private bool dead = false;

    public bool seePlayer = false;
    public bool attackPlayer = false;
    public GameObject heal;
    public GameObject monetaryObject;
    public GameObject offensiveObject;
    public GameObject potionObject;

    void Awake()
    {
        fallCheck = transform.Find("FallCheck");
        wallCheck = transform.Find("WallCheck");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (life <= 0)
        {
            rb.velocity = new Vector2(0, 0);
            transform.GetComponent<Animator>().SetBool("IsDead", true);
            StartCoroutine(DestroyEnemy());
        }

        isPlat = Physics2D.OverlapCircle(fallCheck.position, .2f, 1 << LayerMask.NameToLayer("Default"));
        isObstacle = Physics2D.OverlapCircle(wallCheck.position, .2f, turnLayerMask);

        if (!isHitted && life > 0 && Mathf.Abs(rb.velocity.y) < 0.5f && !attackPlayer)
        {
            if (seePlayer)
            {
                if (facingRight)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                if (canFlip)
                {
                    Flip();
                    canFlip = false;
                    Invoke("CanFlip", 1.5f);
                }
            }
        }

        this.GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float ApplyDamage(float damage)
    {
        if (!isInvincible && life > 0)
        {
            float direction = damage / Mathf.Abs(damage);
            damage = Mathf.Abs(damage);
            transform.GetComponent<Animator>().SetBool("Hit", true);
            life -= damage;
            rb.velocity = Vector2.zero;
            //rb.AddForce(new Vector2(direction * 500f, 100f));
            StartCoroutine(HitTime());
        }
        return life;
    }


    IEnumerator HitTime()
    {
        isHitted = true;
        isInvincible = true;
        yield return new WaitForSeconds(0.1f);
        isHitted = false;
        isInvincible = false;
    }

    IEnumerator DestroyEnemy()
    {
		this.gameObject.transform.Find("Dead").gameObject.GetComponent<BoxCollider2D>().enabled = true;
		this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (!dead)
        {
            dead = true;
            this.transform.Find("Vision").GetComponent<BoxCollider2D>().enabled = false;
            this.transform.Find("AttackVision").GetComponent<BoxCollider2D>().enabled = false;
            this.transform.Find("Attack").GetComponent<EdgeCollider2D>().enabled = false;
            yield return new WaitForSeconds(3f);
            onDeath();
            Destroy(gameObject);
        }
    }
    private void onDeath()
    {
        Vector3 throwDirection = new Vector3(1, 0, 0);
        GameObject drop = this.drop();
        if (drop != null)
        {
            Instantiate(drop, transform.position + new Vector3(1, 1, 1), Quaternion.identity);
        }
    }


    private GameObject drop()
    {
        GameObject drop = null;

        float rand = UnityEngine.Random.Range(0f, 1f);
        if (rand > 0.5f)
        {
            rand = UnityEngine.Random.Range(0f, 1f);
            if (rand > 0.5)
            {
                if (rand > 075f)
                {
                    if (rand > 0.9f)
                    {
                        drop = potionObject;
                    }
                    else
                    {
                        drop = offensiveObject;
                    }
                }
                else
                {
                    drop = heal;
                }

            }
            else
            {
                drop = monetaryObject;
            }
        }
        return drop;
    }

    private void CanFlip()
    {
        canFlip = !canFlip;
    }


}
