using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnPauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseMenu;
    public GameObject Shop;
    public GameObject Inventary;
    public PlayerMovement Player;

    public Text Potions;
    public Text Cauldron;
    public Text Fire;

    public GameObject noMoney;
    private bool noMoneyActive = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Salir()
    {
        Application.Quit();
    }

    public void continuar()
    {
        Cursor.visible = false;
        this.gameObject.GetComponentInParent<PlayerMovement>().canMove = true;
        this.PauseMenu.SetActive(false);
        this.Inventary.SetActive(false);
        this.Shop.SetActive(false);
        Player.canMove = true;
        Time.timeScale = 1;
    }

        public void inventory()
    {
        Cursor.visible = true;
        dataConserved data = dataConserved.DATA;
        Potions.text = data.lifePotions.ToString();
        Fire.text = data.FireBottle.ToString();
        Cauldron.text = data.RedCauldron.ToString();
        Player.canMove = false;
        this.PauseMenu.SetActive(false);
        this.Inventary.SetActive(true);
    }
    public void BuyPotion()
    {
        dataConserved data = dataConserved.DATA;
        if (data.Gems >= 5)
        {
            data.Gems = data.Gems - 5;
            data.lifePotions = data.lifePotions + 1;
            Debug.Log(data.Gems + "Gems");
            Debug.Log(data.lifePotions + "Potions");
        }
        else
        {
            if (!noMoneyActive)
            {
                noMoneyActive = true;
                noMoney.SetActive(true);
                StartCoroutine(ocultNoMoney());
            }
        }
    }
    public void BuyCauldron()
    {
        dataConserved data = dataConserved.DATA;
        if (data.Gems >= 20)
        {
            data.Gems = data.Gems - 20;
            data.RedCauldron = data.RedCauldron + 1;
            Debug.Log(data.Gems + "Gems");
            Debug.Log(data.RedCauldron + "Cauldron");
        }
        else
        {
            if (!noMoneyActive)
            {
                noMoneyActive = true;
                noMoney.SetActive(true);
                StartCoroutine(ocultNoMoney());
            }
        }
    }
    public void BuyFire()
    {
        dataConserved data = dataConserved.DATA;
        if (data.Gems >= 20)
        {
            data.Gems = data.Gems - 20;
            data.FireBottle = data.FireBottle + 1;
            Debug.Log(data.Gems + "Gems");
            Debug.Log(data.FireBottle + "Fire");
        }
        else
        {
            if (!noMoneyActive)
            {
                noMoneyActive = true;
                noMoney.SetActive(true);
                StartCoroutine(ocultNoMoney());
            }
        }
    }

    private IEnumerator ocultNoMoney()
    {
        yield return new WaitForSeconds(2f);
        noMoney.SetActive(false);
        noMoneyActive = false;
    }

    public void guardar(){
        dataConserved.DATA.Scene =  SceneManager.GetActiveScene().name;
        dataConserved.DATA.Save();
    }

}
