using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookAdd : MonoBehaviour
{

    public DialogSystem dialog;
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
        if (other.gameObject.tag.CompareTo("Player") == 0)
        {
            dataConserved.DATA.RelenRecruit = true;
            StartCoroutine(dialog.starDialog(() =>
            {
                SceneManager.LoadScene("Crossroad");
            }
            ));

        }
    }
}
