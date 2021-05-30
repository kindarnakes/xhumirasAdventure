using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMovement : MonoBehaviour
{
    private Transform t;
    private Vector3 origin;
    public float movement = 3.0f;
    public GameObject throwableObject;

    private Animator animator;

    public DialogSystem dialogInDeath;

    private bool canAttack = false;
    private float rand;
    private bool tackle;
    private bool death = false;

    public float life = 50f;

    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        origin = t.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (life <= 0 && !death)
        {
            death = true;
            animator.SetTrigger("Dead");
            StartCoroutine(dead());
        }

        if (canAttack && life > 0)
        {
            canAttack = false;
            rand = Random.Range(0f, 2f);
            if (rand < 1f)
            {
                StartCoroutine(Tackle());
            }
            else
            {
                StartCoroutine(Throw());
            }
        }

        if (tackle && life > 0)
        {
            t.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 0));
        }
        else
        {
            t.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            t.position = origin;
        }


    }

    public IEnumerator initAttact()
    {
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }

    private IEnumerator Tackle()
    {
        animator.SetTrigger("Tackle");
        yield return new WaitForSeconds(1f);
        tackle = true;
        yield return new WaitForSeconds(2f);
        tackle = false;
        yield return new WaitForSeconds(2f);
        canAttack = true;

    }

    private IEnumerator Throw()
    {
        animator.SetTrigger("Summon");
        Vector3 throwDirection = new Vector3(1, 0, 0);
        GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f, 1.4f), Quaternion.identity) as GameObject;
        Vector2 throwed = new Vector2(this.transform.localScale.x * 5, 0f);
        throwableWeapon.transform.localScale = transform.localScale;
        throwableWeapon.GetComponent<summon>().direction = throwDirection;
        throwableWeapon.name = "DeathInvocation";
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }


    private IEnumerator dead()
    {
        death = true;
        yield return new WaitForSeconds(1.8f);
        StartCoroutine(dialogInDeath.starDialog(() =>
        {
            SceneManager.LoadScene("Main_Menu");
        }));

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        dataConserved data = dataConserved.DATA;
        if (other.gameObject.name.CompareTo("Attack") == 0)
        {
            this.ApplyDamage(data.damageMelee());
        }
        else if (other.gameObject.name.CompareTo("PlayerThrowingWeapon") == 0)
        {
            this.ApplyDamage(data.damageRanged());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name.CompareTo("player") == 0)
        {
            other.GetComponent<CharacterController2D>().ApplyDamage(1f, other.transform.position);
        }
    }

    public void ApplyDamage(float damage)
    {
        damage = Mathf.Abs(damage);
        life -= damage;
    }

}
