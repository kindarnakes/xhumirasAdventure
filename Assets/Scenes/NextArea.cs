using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextArea : MonoBehaviour
{

    public String area;
    public DialogSystem dialog;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            if ((dataConserved.DATA.RelenRecruit && area == "RelenRecruit") || (dataConserved.DATA.BennettRecruit && area == "BennettRecruit"))
            {
                StartCoroutine(dialog.starDialog(() =>
                {
                    dataConserved.DATA.conversationPased.Remove("NO_IR");
                }));
            }
            else
            {
                dataConserved.DATA.life = collision.GetComponent<CharacterController2D>().life;
                SceneManager.LoadScene(area);
            }
        }

    }
}
