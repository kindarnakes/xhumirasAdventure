using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCrossroad : MonoBehaviour
{
    public DialogSystem dialog;
    public GameObject Relen;
    public GameObject Bennett;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dialog.starDialog());
        Relen.SetActive(dataConserved.DATA.RelenRecruit);
        Bennett.SetActive(dataConserved.DATA.BennettRecruit);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
