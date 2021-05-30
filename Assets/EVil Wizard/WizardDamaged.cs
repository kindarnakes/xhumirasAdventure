using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDamaged : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

private bool dead =false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var life = 1f;
        dataConserved data = dataConserved.DATA;
        if (other.gameObject.name.CompareTo("Attack") == 0)
        {
            life = this.transform.GetComponentInParent<Wizard>().ApplyDamage(data.damageMelee());
        }
        else if (other.gameObject.name.CompareTo("PlayerThrowingWeapon") == 0)
        {
            life = this.transform.GetComponentInParent<Wizard>().ApplyDamage(data.damageRanged());
            Destroy(other.gameObject);
        }

        if(life <= 0 && !dead){
            dead = true;
            data.addExperience(15f);
        }
    }
}
