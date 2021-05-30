using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    public bool attackPlayer = false;
    bool finishAttack = false;
    public GameObject throwableObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.CompareTo("Player") == 0 && !attackPlayer)
        {
            attackPlayer = true;
            GetComponentInParent<Wizard>().seePlayer = true;
            StartCoroutine(Throw());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag.CompareTo("Player") == 0)
        {
            GetComponentInParent<Wizard>().seePlayer = false;
            attackPlayer = false;
        }
    }


    public IEnumerator Throw()
    {
        this.GetComponentInParent<Animator>().SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        float xPos = transform.parent.localScale.x > 0?2:-2;
        GameObject throwableWeapon = Instantiate(throwableObject, transform.parent.position + new Vector3(xPos, 0, 1) , Quaternion.identity) as GameObject;
        Vector2 direction = new Vector2(transform.parent.localScale.x, 0);
        throwableWeapon.transform.localScale = this.gameObject.transform.parent.localScale;
        throwableWeapon.GetComponent<FireballDamage>().direction = direction;
        throwableWeapon.name = "Fireball";
        if (attackPlayer && !finishAttack)
        {
            finishAttack = true;
            Invoke("delayAttack", 2f);
        }

    }

    private void delayAttack()
    {
        if (attackPlayer && finishAttack)
            StartCoroutine(Throw());
        finishAttack = false;
    }



}
