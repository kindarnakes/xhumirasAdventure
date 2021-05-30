using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    Wizard wizard;

    public bool wall = false;
    // Start is called before the first frame update
    void Start()
    {
        this.wizard = GetComponentInParent<Wizard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.CompareTo("Player") == 0 && !wall)
        {
            wizard.seePlayer = false;
            wizard.GetComponentInChildren<WizardAttack>().attackPlayer = false;
            wizard.Flip();
            wizard.wizardRB.AddForce(other.transform.position.x-transform.position.x > 0?new Vector2(-500, 0):new Vector2(500,0));
        
        }
    }
}
