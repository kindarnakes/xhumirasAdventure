using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark_Sanctuary2Start : MonoBehaviour
{

    public DialogSystem dialog;
    public AudioSource music;
    public DeathMovement enemy;
    public GameObject Relen;
    public GameObject Bennett;
    private bool inEvent = true;
    string dialogName;
    private bool relenEvent = true;
    private bool bennettEvent = true;
    // Start is called before the first frame update
    void Start()
    {
        dialogName = dialog.dialogName;
        StartCoroutine(dialog.starDialog(() =>
        {
            inEvent = false;
            music.Play();
            StartCoroutine(enemy.initAttact());
        }));
    }

    // Update is called once per frame
    void Update()
    {
        if (!inEvent && relenEvent && dataConserved.DATA.RelenRecruit)
        {
            inEvent = true;
            Relen.SetActive(true);
            dialog.dialogName = dialogName + "_RELEN";
            StartCoroutine(dialog.starDialog(() =>
            {
                inEvent = false;
                relenEvent = false;
            }));
        }

        if (!inEvent && bennettEvent && dataConserved.DATA.BennettRecruit)
        {
            inEvent = true;
            Bennett.SetActive(true);
            dialog.dialogName = dialogName + "_BENNETT";
            Debug.Log(dialog.dialogName);
            StartCoroutine(dialog.starDialog(() =>
            {
                bennettEvent = false;
                inEvent = false;
                enemy.life /= 2;
            }));
        }

    }
}
