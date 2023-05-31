using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public ItemGeneral inventory;
    public int iq;

    private float Distance;
    private Transform plrTransform;

    public GameObject idinaxuysuka;

    private bool iqtrue = false;

    void Start()
    {
        plrTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        idinaxuysuka.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(transform.position, plrTransform.position);

        if(iq >= 50){ iqtrue = true; } else if(iq < 50){ iqtrue = false; }

        if(Distance < 1.5){
            idinaxuysuka.gameObject.SetActive(true);
            if(iqtrue){
                if(inventory.values[3] >= 3 && Input.GetKeyDown("g")){
                    inventory.values[3] = inventory.values[3]-3;
                    inventory.values[4] = inventory.values[4]+1;
                }
            }
        }
        else{
            idinaxuysuka.gameObject.SetActive(false);
        }
    }
}
