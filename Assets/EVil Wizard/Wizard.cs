using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{

    public bool seePlayer = false;
    public bool flip = true;

    bool isInvincible = false;
    public float life = 20;

    private bool dead = false;
    public GameObject heal;
    public GameObject monetaryObject;
    public GameObject offensiveObject;
    public GameObject potionObject;
    public Rigidbody2D wizardRB;
    // Start is called before the first frame update
    void Start()
    {
        this.wizardRB = GetComponent<Rigidbody2D>();
        Invoke("canFlip", 1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!dead && life <= 0)
        {
            dead = true;
            GetComponent<Animator>().SetTrigger("Death");
            StartCoroutine(DestroyEnemy());
        }
    }

    void FixedUpdate()
    {
        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(wizardRB.velocity.x));
        if (!seePlayer && !flip)
        {
            flip = true;
            Invoke("Flip", 1f);
            Invoke("canFlip", 2f);
        }
    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void canFlip()
    {
        flip = false;
    }


    public float ApplyDamage(float damage)
    {
        if (!isInvincible && life > 0)
        {
            float direction = damage / Mathf.Abs(damage);
            damage = Mathf.Abs(damage);
            GetComponent<Animator>().SetTrigger("Hit");
            life -= damage;
            wizardRB.velocity = Vector2.zero;
            //rb.AddForce(new Vector2(direction * 500f, 100f));
            StartCoroutine(HitTime());
        }
        
        return life;
    }


    IEnumerator HitTime()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.1f);
        isInvincible = false;
    }

    IEnumerator DestroyEnemy()
    {
        this.transform.Find("Vision").GetComponent<BoxCollider2D>().enabled = false;
        this.transform.Find("AttackVision").GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(3f);
        onDeath();
        Destroy(gameObject);
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

        float rand = Random.Range(0f, 1f);
        if (rand > 0.5f)
        {
            rand = Random.Range(0f, 1f);
            if(rand > 0.5){
                if(rand > 075f){
                    if(rand > 0.9f){
                        drop = potionObject;
                    }else{
                        drop = offensiveObject;
                    }
                }else{
                    drop = heal;
                }

            }else{
                drop = monetaryObject;
            }
        }



        return drop;
    }


}
