using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSanctuaryStart : MonoBehaviour
{

    public DialogSystem dialog;
    public AudioSource music;
    public DeathMovement enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dialog.starDialog(() => {
            music.Play();
            StartCoroutine(enemy.initAttact());
        }));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
