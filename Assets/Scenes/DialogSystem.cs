using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public string dialogName;
    public Text textArea;
    public Text textName;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator starDialog()
    {
        StartCoroutine(starDialog(() => { }));
        yield return null;

    }


    public IEnumerator starDialog(Action finish)
    {
        if (!dataConserved.DATA.conversationPased.Contains(this.dialogName))
        {
            dataConserved.DATA.conversationPased.Add(this.dialogName);
            float time = 0.00001f;
            List<Dialogs.Dialog> dialog = Dialogs.Instance.dialogs[this.dialogName];
            GameObject text = textArea.gameObject.transform.parent.gameObject;
            GameObject name = textName.gameObject.transform.parent.gameObject;
            text.SetActive(true);
            name.SetActive(true);
            Time.timeScale = time;

            for (int i = 0; i < dialog.Count; i++)
            {
                textName.text = dialog[i].name;
                textArea.text = "";
                for (int j = 0; j < dialog[i].dialog.Length; j++)
                {
                    textArea.text = textArea.text + dialog[i].dialog[j];
                    yield return new WaitForSeconds(time * 0.05f);
                }

                yield return new WaitForSeconds(time * 1.5f);
            }
            dataConserved.DATA.conversationPased.ForEach(c => {
                Debug.Log(c);
            });
            text.SetActive(false);
            name.SetActive(false);
            Time.timeScale = 1f;
            finish();
        }
    }
}
