using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalRecruit : MonoBehaviour
{
    public Enemy enemy;
    public DialogSystem dialog;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator start(){
        yield return new WaitUntil(() => enemy.life <= 0);
            StartCoroutine(dialog.starDialog(() =>{
                dataConserved.DATA.BennettRecruit = true;
                SceneManager.LoadScene("Crossroad");
            }));

    }
}
