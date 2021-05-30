using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public Wizard wizard;
    public Camera newcamera;

    public PlayerMovement Player;

    public AudioSource actualSound;

    public DialogSystem dialog;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float life = 1;
        if (wizard != null)
        {
            life = wizard.life;
        }

        if (!done && life <= 0)
        {
            StartCoroutine(shake());
        }
    }


    private IEnumerator shake()
    {
        CameraFollow cameraFollow = newcamera.GetComponent<CameraFollow>();
        this.Player.canMove = false;
        Transform actual = cameraFollow.Target;
        cameraFollow.Target = this.transform;
        actualSound.mute = true;
        GetComponent<AudioSource>().Play(0);
        cameraFollow.shakeDuration = 12f;
        cameraFollow.shakeAmount = 0.8f;
        yield return new WaitForSeconds(15f);
        actualSound.mute = false;
        cameraFollow.Target = actual;

        StartCoroutine(dialog.starDialog(() =>
        {
            this.gameObject.SetActive(false);
            this.Player.canMove = true;
        }));

    }
}
