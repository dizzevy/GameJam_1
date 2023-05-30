using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    public float speed;
    private Transform target;
    
    private float Distance;
    private Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Distance = Vector3.Distance(transform.position, target.position);

        if(Distance < 7){
            animator.SetBool("SlimeJump", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);

            if (transform.position.x > target.position.x) {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else {
                transform.rotation = Quaternion.Euler(0, 0, 0); 
            }
        }
        else{
            animator.SetBool("SlimeJump", false);
        }
    }
}
