using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goku_control : MonoBehaviour
{

    public float maxspeed = 5f;
    public float speed = 20f;

    public bool grounded;
    public bool super_sayan;
    public bool ulta_instinct;
    public Transform kamekame_origen;
    public bool kamekameha;
    public Ataques_Goku ataques;
    public string escena_actual;

    public float jumpPower = 5f;
    public float SuperJumpPower = 9f;
    public kamekameha kamekame_active_anim;
    public bool jump;
    public bool DoobleJump;
    public bool super_jump;
    private Rigidbody2D knight;
    private Animator anim2;
    private bool movimiento = true;
    private SpriteRenderer spr; //cambiar el color cuando nos pegan
    public GameObject SonidoSalto;
    public GameObject SuperSalto;
    public GameObject TransformarGoku;
    public GameObject SonidoCaer;
    public GameObject SonidoDisparo;
    public GameObject SonidoPuñetazos;

    public int vidas = 3;
    public bool entra = false;


    // Start is called before the first frame update
    void Start()
    {
        knight = GetComponent<Rigidbody2D>();
        anim2 = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim2.SetFloat("Velocity", Mathf.Abs(knight.velocity.x));
        anim2.SetBool("Grounded", grounded);
        anim2.SetBool("Super_sayan_1",super_sayan);
        anim2.SetBool("Ultra_instinct", ulta_instinct);

        if (grounded)
        {
            DoobleJump = true;
        }

        if (Input.GetButtonDown("L1") || Input.GetKeyDown("1") && super_sayan == false)
        {
            super_sayan = true;
        }

        if (Input.GetButtonDown("R1") || Input.GetKeyDown("2")) {
            Instantiate(TransformarGoku);//sonido transformar
            ulta_instinct = true;
        }

        if (Input.GetButtonDown("B") || Input.GetKeyDown("q")) {
            Instantiate(SonidoPuñetazos);//Sonido Puñetazos
            anim2.SetTrigger("Ataque");
        }


        if (Input.GetButtonDown("X") || Input.GetKeyDown("w"))
        {
            Instantiate(SonidoDisparo);//sonido Disparo
            kamekameha = true;
            kamekame_active_anim.kamekame = true;
            anim2.SetTrigger("Kamekameha");
            Invoke("fin_kamekame", 0.02f);
        }

        if (Input.GetButtonDown("A") || Input.GetKeyDown("space"))
        {
            if (grounded)
            {
                Instantiate(SonidoSalto);//sonido saltar
                jump = true;
                DoobleJump = true;
            }
            else if (DoobleJump)
            {
                Instantiate(SonidoSalto);//sonido saltar
                jump = true;
                DoobleJump = false;
            }

        }
        if (Input.GetButtonDown("Y")||Input.GetKeyDown("e") && grounded)
        {
            Instantiate(SuperSalto);//sonido supersalto
            super_jump = true;
        }

    }
    void fin_kamekame() {
        kamekameha = false;
    }

    void OnDisable()
    {
        PlayerPrefs.SetString("scene", escena_actual);
    }

    void OnBecameInvisible() //Reaparecen en el mapa
    {
        Instantiate(SonidoCaer); //sonido Caer
        Scene scene = SceneManager.GetActiveScene();
        vidas--;
        if (vidas != 0)
        {
            if (scene.name == "Zone1")
            {
                transform.position = new Vector3(-13, 20, 0);
            }
            else if (scene.name == "Zone2")
            {
                transform.position = new Vector3(0, 25, 0);
            }
            else if (scene.name == "Zone3")
            {
                transform.position = new Vector3(0, 15, 0);
            }
            else if (scene.name == "Zone4")
            {
                transform.position = new Vector3(-37, 51, 0);
            }
            else if (scene.name == "Zone5")
            {
                transform.position = new Vector3(-12, 2, 0);
            }
            else if (scene.name == "Juego_Principal")
            {
                transform.position = new Vector3(-43, 15, 0);
            }

        }
        else
        {
            if(entra == false)
            {
                escena_actual = SceneManager.GetActiveScene().name;
                OnDisable();
                SceneManager.LoadScene("Loser");
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //solo detecta cuando choca por primera vez
    {
        if (collision.gameObject.tag == "Escena")
        {
            entra = true;
        }
    }

    public void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        if(h == 0) {
            h = Input.GetAxis("HorizontalLR");
        }
        
        if (movimiento == false) h = 0;
        knight.AddForce(Vector2.right * speed * h);
       
        if (h > 0.1f) { 
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (knight.velocity.x > maxspeed) {
            knight.velocity = new Vector2(maxspeed, knight.velocity.y);
        }

        if (knight.velocity.x < -maxspeed)
        {
            knight.velocity = new Vector2(-maxspeed, knight.velocity.y);
        }

        if (jump) {
            knight.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        if (super_jump) {
            knight.AddForce(Vector2.up * SuperJumpPower, ForceMode2D.Impulse);
            super_jump = false;
        }
    }
    public void EnemyJump() {
        jump = true;
    }

    public void EnemyGolpe(float enemy_pos)
    {
        knight.velocity = new Vector3(0f, 0f,0f);
        grounded = true;
        float lado = Mathf.Sign(enemy_pos - transform.position.x);//dedvuelve -1,1 o 0 en funcion del signo
        knight.AddForce(Vector2.left * lado * (jumpPower - 17), ForceMode2D.Impulse);
        knight.AddForce(Vector2.up * (jumpPower - 17), ForceMode2D.Impulse);
        movimiento = false; //para que cuando nos hayan pegado no nos podamos mover
        Invoke("Activar_movimiento", 0.7f);
        spr.color = Color.red;
        vidas--;
        if(vidas == 0)
        {
            escena_actual = SceneManager.GetActiveScene().name;
            print(escena_actual);
            SceneManager.LoadScene("Loser");
        }
    }
    void Activar_movimiento()
    {
        movimiento = true;
        spr.color = Color.white;
    }
}
