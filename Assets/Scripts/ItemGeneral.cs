using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ItemGeneral : MonoBehaviour
{
    public int[] values = { 0, 0, 0, 0, 0  };
    public string[] names = { "Log", "Stone", "Stick", "String",  "Rope" };
    public TMP_Text[] texts = { null, null, null, null, null };

    public void SunutInt(string name){
        for(int b=0;b<values.Length;b++){
            if(name == names[b]){
                values[b] = values[b]+1;
                break;
            }
        }
    }

    void Update(){
        for(int a=0;a<texts.Length;a++){
            texts[a].text = values[a].ToString();
        }
    }
}