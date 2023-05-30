using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choppable : MonoBehaviour
{
    public int iq = 50; // айкю
    public float needDist = 1.5f; // дистанция до объекта чтобы его ломать

    public int health;

    public GameObject result;

    private Transform plrTransform; // Transform игрока

    private float Distance; // дистанция
    private bool iqtrue = false; // больше или равно айкю кол-ву

    private bool can_damage =  true; // можно ли нанести урон

    private Animator animator; // получаем аниматор

    IEnumerator Damage(int damage){
        if(can_damage == true){
            animator.SetBool("Shake", true);
            can_damage = false; // выставляем значение то что дамаг нанести нельзя
            health = health-damage; // сносим урон
            yield return new WaitForSeconds(2); // ожидаем кул-дауна (кд)
            can_damage = true; // выставляем значение то что дамаг нанести можно
            animator.SetBool("Shake", false);
        }
    }

    IEnumerator Kill(){
        animator.SetBool("Drop", true); // играем анимацию
        yield return new WaitForSeconds(1.983f); // ожидаем кул-дауна (кд)
        for(int i=1;i<Random.Range(2, 5);i++){
            GameObject gg = GameObject.Instantiate(result);
            gg.GetComponent<Transform>().position = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), transform.position.z);
        }
        Destroy(this.gameObject); // удаляем
    }

    void Start(){
        plrTransform = GameObject.FindWithTag("Player").GetComponent<Transform>(); // получение Transform игрока
        animator = gameObject.GetComponent<Animator>(); // получаем аниматор
    }

    void Update()
    {
        if(iq >= 50){ iqtrue = true; } else if(iq < 50){ iqtrue = false; } // iq проверка
        Distance = Vector3.Distance(transform.position, plrTransform.position); // считаем дистанцию

        if(health == 0){ // проверяем срубленно ли дерево
            StartCoroutine(Kill()); // убиваем дерево :)
        }

        if(Distance < needDist && iqtrue == true){ // проверка дистанции и есть ли у игрока больше определённого кол-ва айкю
            if(Input.GetKeyDown("e")){
                StartCoroutine(Damage(1)); // запускаем корутину (функцию) дамага
            }
        }
    }
}
