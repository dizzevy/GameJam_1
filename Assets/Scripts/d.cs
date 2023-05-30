using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class d : MonoBehaviour
{
    public TMP_Text tytext;
    private string text;

    private void Start() {
        text = tytext.text;
        tytext.text = "";
        StartCoroutine(TextCoroutine());
    }
    IEnumerator TextCoroutine()
    {
        foreach(char abc in text)
        {
            tytext.text += abc;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
