using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    public GameObject Main;
    public GameObject OptionsMenu;
    public Toggle Windowed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Screen.fullScreen = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Iniciar()
    {

        Cursor.visible = false;
        dataConserved.DATA.startGame();
        SceneManager.LoadScene("Forest");
    }

    public void options()
    {
        Main.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void back()
    {
        Main.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void windowed()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(1024, 576, false, 60);
        }
        else
        {
            Screen.SetResolution(Screen.resolutions.Last().width, Screen.resolutions.Last().height, true, 60);
        }
    }

    public void Cargar()
    {
        dataConserved data = dataConserved.DATA;
        data.Load();
        if (data.Scene == "Forest")
        {
            data.startGame();
            SceneManager.LoadScene("Forest");
        }
        else
        {
            SceneManager.LoadScene(data.Scene);
        }

    }

    public void Salir()
    {
        Application.Quit();
    }
}
