using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cntr_rana : MonoBehaviour
{
    public float maxspeed = 1f;
    public float speed = 1f;
    public zorroplayer scriptplayer;
    //private int estado = 1;
    public int quiet = 0;
    public int mov = 0;
    public int num_rana = 0;
    public int transicion = 0;
    public bool rana_muere = false;
    public bool rebote = false;
    public bool rebote_lateral = false;
    private int veces = 0; // numero de veces que esta en estado quieto.

    public Transform from;
    public Transform to;
    public Transform target;
    public AudioClip audiomuerte;
    public AudioClip muertezorro;
    private Vector3 startplat;
    private Vector3 startarget;
    private Animator anim;
    private AudioSource audioRana;
    private bool muerte = false;
    private bool sonido = false;
    private int comp = 0;
    private int esperar = 0;
    Rigidbody2D ranaR;


    void OnDrawGizmosSelected()
    {
        if (from != null && to != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(from.position, to.position);

        }
    }

    void Update()
    {
        anim.SetInteger("estado", transicion);
        quiet = anim.GetBehaviour<reposo>().quieto;
        mov = anim.GetBehaviour<accion>().move;
        audioRana = GetComponent<AudioSource>();
    }
    void Start()
    {
        if (target != null)
        {
            target.parent = null; // hacemos que no sea hijo de la plataforma y sea independiente.
        }
        ranaR = GetComponent<Rigidbody2D>();
        startplat = transform.position;
        startarget = target.position;
        anim = GetComponent<Animator>();
        transform.localScale = new Vector3(1f, 1, 1);
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
       
        if (target != null) //Para estar seguro de que lo hemos asignado.
        {
            if (quiet == 1)
            {
                if (veces == 100)
                {
                    transicion = 1;
                    veces = 0;
                }
                transform.position = transform.position;
                veces = veces + 1;
                
            }
            if(mov == 1)
            {
                transicion = 2;
                float fixedspeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, fixedspeed); //posicion actual, donde queremos ir, speed.
                
            }
        }

        if (transform.position == target.position)
        {
            if (target.position == startplat)
            {
                target.position = startarget;
                transform.localScale = new Vector3(1f, 1, 1);
            }
            else
            {
                target.position = startplat;
                transform.localScale = new Vector3(-1f, 1, 1);
            }

        }
        if (rana_muere == true)
        {
            audioRana.clip = audiomuerte;
            audioRana.Play();
            
            sonido = true;
            rana_muere = false;
        }
        if (sonido == true)
        {
            esperar = esperar + 1;
            if (esperar == 30)
            {
                
                print(esperar);
                esperar = 0;
                Destroy(gameObject); // SE MUERE LA RANA
                scriptplayer.numenemy = scriptplayer.numenemy + 1;
                num_rana = num_rana + 1;

            }

        }
        if (rebote_lateral == true)
        {
            comp = comp + 1;
            if (comp == 150)
            {
                comp = 0;
                SceneManager.LoadScene("Loser");
                rebote_lateral = false;
            }

        }

    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yoffset = 1.2f;
            if (transform.position.y + yoffset < col.transform.position.y)
            {
                print("SOY RANITA ME MUERO");
                rana_muere = true;
                rebote = true;
                //Destroy(gameObject); // SE MUERE LA RANA
                //scriptplayer.numenemy = scriptplayer.numenemy + 1;
                //num_rana = num_rana + 1;
                

            }
            else
            {
                rebote_lateral = true;
                audioRana.clip = muertezorro;
                audioRana.Play();
                //Destroy(col.gameObject); // SE MUERE EL PERSONAJE ASI QUE CAMBIO DE ESCENA.
                //SceneManager.LoadScene("Loser");
            }
        }
    }
}