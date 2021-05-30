using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDarkCave : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public Camera newcamera;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        newcamera.transform.position = Player.transform.position;
        StartCoroutine(dialogSystem.starDialog(() =>
        {
            //Time.timeScale = 1f;
        }));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
