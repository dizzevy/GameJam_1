using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    
    private float score;
    private float Distance;
    public float NeedDistance;
    

    void Start() {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
    private void FixedUpdate() {
        if(Distance < NeedDistance){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            if(transform.position.x > target.position.x) {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            } else {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            
            }
        }
    }

    private void Update() {
        Distance = Vector3.Distance(target.position, transform.position);
    }

}
