using System.Threading;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public DialogSystem dialogSystem;

    public GameObject toActivate;
    public GameObject darkScreen;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        StartCoroutine(dialogSystem.starDialog(() =>
        {
            Time.timeScale = 0f;
            darkScreen.SetActive(false);
            toActivate.SetActive(true);
        }));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartPlay()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        toActivate.SetActive(false);
    }
}
