using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Iniciar(){
       
       Cursor.visible = false;
       SceneManager.LoadScene("Forest");
   }

   public void Cargar(){
       dataConserved data = dataConserved.DATA;
       data.Load();
       SceneManager.LoadScene(data.Scene);

   }

   public void Salir(){
       Application.Quit();
   }
}
