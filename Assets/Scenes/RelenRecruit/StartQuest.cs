using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuest : MonoBehaviour
{
    public DialogSystem dialog;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dialog.starDialog());    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
