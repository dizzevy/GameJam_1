using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typingEffect : MonoBehaviour
{
    public TMP_Text tytext;
    private string text;

    private void Start()
    {
        text = tytext.text;
        tytext.text = "";
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        int index = 0;
        while (index < text.Length)
        {
            tytext.text += text[index];
            index++;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
