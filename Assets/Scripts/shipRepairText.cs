using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shipRepairText : MonoBehaviour
{
    public TMP_Text RepairText;

    void Start() {
        RepairText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            RepairText.gameObject.SetActive(true);    
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("sdf");
            RepairText.gameObject.SetActive(false);    
        }
    }
}
