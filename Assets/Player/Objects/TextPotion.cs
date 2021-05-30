using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPotion : MonoBehaviour
{

    public CharacterController2D player;
    public Text textArea;
    public Text nPotions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void textOn() {
        textArea.text = "La poción roja cura un poco de vida.";
        textArea.gameObject.SetActive(true);
    }

    public void textOff() {
        textArea.gameObject.SetActive(false);        
    }
    public void heal(){
        dataConserved data = dataConserved.DATA;
        var actualLife = player.life;
        if (data.maxLife > actualLife && data.lifePotions > 0)
        {
            this.gameObject.GetComponentInParent<CharacterController2D>().heal(5f);
            data.lifePotions -= 1;
            nPotions.text = data.lifePotions.ToString();
        }

    }
}
