using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emoji : MonoBehaviour
{
    public GameObject[] emoji;
    public int started;

    void Start()
    {
        for(int b=0;b<emoji.Length;b++){
            emoji[b].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(started == 0){
            emoji[0].gameObject.SetActive(false);
            emoji[1].gameObject.SetActive(false);
        }
        else if(started == 1){
            emoji[0].gameObject.SetActive(true);
        }
        else if(started == 2){
            emoji[1].gameObject.SetActive(true);
        }
    }
}
