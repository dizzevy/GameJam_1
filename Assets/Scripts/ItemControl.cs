using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemControl : MonoBehaviour
{
    public ItemGeneral itemGeneral;
    public string thisname;
    public PlayerController playerController;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerController.iq >=35)
        {
            itemGeneral.SunutInt(thisname);
            Destroy(this.gameObject);
        }

    }
}
    
