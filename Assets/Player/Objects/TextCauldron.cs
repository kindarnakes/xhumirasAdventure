using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCauldron : MonoBehaviour
{

    public Text textArea;
    public CharacterController2D player;
    public Text nCauldron;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void textOn()
    {
        textArea.text = "El caldero rojo te cura mucha vida.";
        textArea.gameObject.SetActive(true);
    }

    public void textOff()
    {
        textArea.gameObject.SetActive(false);
    }

    public void heal()
    {
        dataConserved data = dataConserved.DATA;
        var actualLife = player.life;
        if (data.maxLife > actualLife && data.RedCauldron > 0)
        {
            this.gameObject.GetComponentInParent<CharacterController2D>().heal(10f);
            data.RedCauldron -= 1;
            nCauldron.text = data.RedCauldron.ToString();
        }

    }

}
