using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    public bool ok = false;
    
    public float speed ;
    public Transform target_enemy;
    private Vector3 start, end;
    public Knight_control knight;
    public Goku_control goku;
    public kamekameha kamekameha;
    private Vector3 posicion;
    public bool lanzada;
    private Animator anim;
    private SpriteRenderer spr;
    public bool muere = false;
    // private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        // rb2d = GetComponent<Rigidbody2D>();
        if (target_enemy != null)
        {
            target_enemy.parent = null;
            start = transform.position; 
            end = target_enemy.position; 
        }

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Lanzada", lanzada);
        anim.SetBool("Muere", muere);
    }

    private void FixedUpdate()
    {
        if (target_enemy != null)
        {
            float FixedSpeed = speed * Time.deltaTime; //Necesitamos hacer esto para meter la veloicad en MoveTowards
            //a MoveTowards se le pasan 3 valores: punto actual donde estamos, obejtivo a donde vamos
            //y la velocidad
            transform.position = Vector3.MoveTowards(transform.position, target_enemy.position, FixedSpeed);
        }

        if (transform.position == target_enemy.position)
        {
            
            target_enemy.position = (target_enemy.position == start) ? end : start; //si la posicion actual vale start, 

            if(target_enemy.position == end)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            
            }
         
             if(target_enemy.position == start)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
               
            }
            

        }



      
    }

    void Stop_lanzada()
    {
        lanzada = false;
    }

    void Muere()
    {
         Destroy(gameObject);
       
    }

   /* public void Destruir() {

        
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Attack")
        {
            speed = 0;
            float FixedSpeed = speed * Time.deltaTime;
            muere = true;
            Invoke("Muere", 0.7f);
           
            // spr.color = Color.red;
            transform.position = Vector3.MoveTowards(transform.position, target_enemy.position, FixedSpeed);

        }


        if (collision.gameObject.tag == "Player")
        {
            posicion = transform.localScale;
            if(transform.position.x < collision.transform.position.x)
            {
                if(transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    lanzada = true;
                    Invoke("Stop_lanzada", 0.1f);

                }
                else
                {
                    lanzada = true;
                    Invoke("Stop_lanzada", 0.1f);
                }
            }
            else
            {
                if(transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    lanzada = true;
                    Invoke("Stop_lanzada", 0.1f);
                }
                else
                {
                    lanzada = true;
                    Invoke("Stop_lanzada", 0.1f);
                }
            }
            
            if (transform.position.y + 2 < collision.transform.position.y)
            {
                goku.EnemyJump();
                knight.EnemyJump();
                
                Destroy(gameObject);
            }
            else
            {
                goku.EnemyGolpe(transform.position.x);
                knight.EnemyGolpe(transform.position.x);
            }
        }
    }

    
}

