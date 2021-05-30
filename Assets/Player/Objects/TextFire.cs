using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFire : MonoBehaviour
{

    public Text textArea;
    public Text nPotions;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{

   // }

    public void textOn()
    {
        textArea.text = "El vial de fuego hace que puedas lanzar tu arma con fuego.";
        textArea.gameObject.SetActive(true);
    }

    public void textOff()
    {
        textArea.gameObject.SetActive(false);
    }

    public void fire()
    {
        dataConserved data = dataConserved.DATA;
        if (!data.isFireDamage)
        {
            data.isFireDamage = true;
            data.FireBottle -= 1;
            nPotions.text = data.FireBottle.ToString();
        }

    }    

    void Update()
    {

    }
}
