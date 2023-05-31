using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shipRepair : MonoBehaviour
{
    public ItemGeneral itemGeneral;
    public int needLog = 15;
    public int needStone = 4;
    public int needStick = 3;
    public int needString = 2;
    public int needRope;

    private bool isInTrigger;
    private bool isRepairing = false;

    private void Start() 
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E) && !isRepairing && isInTrigger)
        {
            isRepairing = true;
            if(itemGeneral.values[0] >= needLog && itemGeneral.values[1] >= needStone && itemGeneral.values[2] >= needStick && itemGeneral.values[3] >= needString && itemGeneral.values[4] >= needRope)
            {
                itemGeneral.values[0] -= needLog; itemGeneral.values[1] -= needStone; itemGeneral.values[2] -= needStick; itemGeneral.values[3] -= needString; itemGeneral.values[4] -= needRope;
                Debug.Log("корабль починен");
            }
            else
            {
                Debug.Log("Недостаточно рессурсов для починки корабля");
            }
            isRepairing = false;

        }
    }
}



// if(other.CompareTag("Player")&& !isRepairing)
//         {

//             isRepairing = true;
//             if(itemGeneral.values[0] >= needLog && itemGeneral.values[1] >= needStone && itemGeneral.values[2] >= needStick && itemGeneral.values[3] >= needString && itemGeneral.values[4] >= needRope)
//             {
//                 itemGeneral.values[0] -= needLog; itemGeneral.values[1] -= needStone; itemGeneral.values[2] -= needStick; itemGeneral.values[3] -= needString; itemGeneral.values[4] -= needRope;
//                 Debug.Log("корабль починен");
//             }
//             else
//             {
//                 Debug.Log("Недостаточно рессурсов для починки корабля");
//             }
//             isRepairing = false;

//         }
