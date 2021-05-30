using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBennett : MonoBehaviour
{
    public DialogSystem dialog;
    public AudioSource newaudio;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dialog.starDialog(() =>
            newaudio.Play()
        ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
