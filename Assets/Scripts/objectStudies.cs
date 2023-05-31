using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class objectStudies : MonoBehaviour
{
    private bool isTrigger;
    private bool isStuding;
    private bool isPlayerInside;
    public TMP_Text PressEText;
    private float studyTimer = 0f;
    public float studyTime = 5f; // время , необходимое для изучения объекта
    public float iq = 1f;
    public PlayerController playerController;
    


    void Start() {
        PressEText.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            isTrigger = true;
            PressEText.text = "Press 'E' to study the object";
            PressEText.enabled = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            isTrigger = false;
            PressEText.enabled = false;
            if (!isPlayerInside)
            {
                StopStudying();
            }
            

        }
    }

    private void Update() 
    {

        if(isTrigger && !isStuding && Input.GetKeyDown(KeyCode.E))
        {
            isStuding = true;
            Debug.Log("УЧУСЬ...");
            studyTimer = studyTime;
            PressEText.text = "Studying object - " + studyTimer.ToString("F0") + "...";
        }


        if (isStuding)
        {
            studyTimer -= Time.deltaTime;
            PressEText.text = "Studying object - " + studyTimer.ToString("F0") + "...";

            if (studyTimer <= 0f)
            {
                isStuding = false;
                IncreaseIQ();
                Destroy(this.gameObject);
            }
        }
        
    }

   private void StopStudying()
   {

        isStuding = false;

   }
   
        

    private void IncreaseIQ(){
        playerController.iq += 2f;

    }

    
}
