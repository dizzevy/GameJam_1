using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemControl : MonoBehaviour
{
    public ItemGeneral ChatGPT;
    public string thisname;

    void OnTriggerEnter2D(Collider2D collision)
    {
        ChatGPT.SunutInt(thisname);
        Destroy(this.gameObject);
    }
}
