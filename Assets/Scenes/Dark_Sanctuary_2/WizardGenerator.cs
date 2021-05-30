using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardGenerator : MonoBehaviour
{
    public GameObject instantiate;
    private GameObject instancia = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(instancia == null && !dataConserved.DATA.RelenRecruit){
            instancia = Instantiate(instantiate, transform.position + new Vector3(transform.localScale.x * 0.5f, 1.4f), Quaternion.identity) as GameObject;
        }
        
    }
}
