using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float dmgValue = 4;
    public GameObject throwableObject;
    public Transform attackCheck;
    private Rigidbody2D m_Rigidbody2D;
    public Animator animator;
    public bool canAttack = true;
    public bool isTimeToCheck = false;

    public bool canThrow = true;

    public GameObject cam;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && canAttack && !animator.GetBool("IsJumping"))
        {
            canAttack = false;
            animator.SetBool("IsAttacking", true);
            StartCoroutine(AttackCooldown());
        }

        if (Input.GetKeyDown(KeyCode.V) && canThrow)
        {
            canThrow = false;
            animator.SetBool("IsThrowing", true);
            Invoke("Throw", 0.4f);
            Invoke("CanThrow", 0.5f);
            AttackCooldown();
        }
    }

    public void CanThrow()
    {
        canThrow = true;
    }
    private bool coroutine = false;
    public void Throw()
    {

        GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(animator.gameObject.transform.localScale.x * 0.5f, 1.4f), Quaternion.identity) as GameObject;
        Vector2 direction = new Vector2(animator.gameObject.transform.localScale.x, -0.2f);
        if (dataConserved.DATA.isFireDamage)
        {
            throwableWeapon.transform.Find("Fire").gameObject.SetActive(true);
            if (!coroutine)
            {
                StartCoroutine(finishFire());
                coroutine = true;
            }
        }
        else
        {
            throwableWeapon.transform.Find("Fire").gameObject.SetActive(false);
        }
        throwableWeapon.transform.localScale = animator.gameObject.transform.localScale;
        throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction;
        throwableWeapon.name = "PlayerThrowingWeapon";
    }

    public IEnumerator finishFire()
    {
        yield return new WaitForSecondsRealtime(15f);
        dataConserved.DATA.isFireDamage = false;
        coroutine = false;
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }

    public void DoDashDamage()
    {
        dmgValue = Mathf.Abs(dmgValue);
        Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
        for (int i = 0; i < collidersEnemies.Length; i++)
        {
            if (collidersEnemies[i].gameObject.tag == "Enemy")
            {
                if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
                {
                    dmgValue = -dmgValue;
                }
                collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
                cam.GetComponent<CameraFollow>().ShakeCamera();
            }
        }
    }


}
