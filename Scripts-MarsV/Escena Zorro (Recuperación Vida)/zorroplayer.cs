using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zorroplayer : MonoBehaviour
{
    public float maxspeed = 10f;
    public float speed = 50f;
    public bool suelo;
    public float salto = 25.0f;
    public float escala = 6f;
    public int numcoin = 0;
    public int numenemy = 0;
    public bool herido = false;
    public AudioClip audiomoneda;
    public AudioClip audiosalto;
    public Cntr_rana scriptrana;
    public AudioClip audiomuerterana;
    public AudioClip audiomuertezorro;
    Rigidbody2D zorroR;
    private float side = 0.0f;
    private float posX = 0.0f;
    private bool rana_muerta = false;
    private Animator anim;
    private bool saltar;
    private SpriteRenderer spr;
    private int wait = 0;
    private bool entagua = false;
    private AudioSource audioPlayer;
    private int sonido = 0;
    private bool una_vez = false;
    private bool rebote = false;
    private bool rebote_lateral = false;
    private bool desactivar = false;
    private bool first = false;
 

    // Start is called before the first frame update
    void Start()
    {
        zorroR = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        audioPlayer = GetComponent<AudioSource>();
        rana_muerta = scriptrana.rana_muere;
        rebote = scriptrana.rebote;
        rebote_lateral = scriptrana.rebote_lateral;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(zorroR.velocity.x));
        anim.SetBool("tierra", suelo);
        anim.SetBool("Hurt", herido);

       
       

        if ((Input.GetButtonDown("A") || Input.GetKeyDown("space")) && suelo)
        {
            saltar = true;
        }
    }

    void FixedUpdate()
    {
        /*if (rana_muerta == false && una_vez == false)
        {
            rana_muerta = scriptrana.rana_muere;
        }
       
        if (rana_muerta == true)
        {
            print("RANA_MATADA");
            sonido = sonido + 1;
            audioPlayer.clip = audiomuerterana;
            audioPlayer.Play();
            print(sonido);
            una_vez = true;
            rana_muerta = false;
            
           

        }
         */
        if (desactivar == false && rebote == false)
        {
            rebote = scriptrana.rebote;
        }
        if (rebote == true)
        {
            zorroR.velocity = new Vector2(zorroR.velocity.x, 0);
            zorroR.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            desactivar = true;
            rebote = false;
        }
        if (desactivar == false && rebote_lateral == false)
        {
            rebote_lateral = scriptrana.rebote_lateral;
        }
        if (rebote_lateral == true)
        {
            
            print("lateral");
            side = Mathf.Sign(-posX + transform.position.x);
            zorroR.AddForce(Vector2.left * side * 50.0f, ForceMode2D.Impulse);
            zorroR.AddForce(Vector2.up * 10.0f, ForceMode2D.Impulse);
            desactivar = true;
            rebote_lateral = false;
            Destroy(gameObject);
        }
        spr.color = Color.white;
        herido = false;
        if (entagua == true)
        {
            if (first == false)
            {
                if (audioPlayer.clip == audiosalto)
                {
                    audioPlayer.Stop();
                }
                audioPlayer.clip = audiomuertezorro;
                audioPlayer.Play();
                print("entro agua");
                first = true;
            }
            wait = wait + 1;
            print(wait);
            if (wait == 150)
            {
                SceneManager.LoadScene("Loser");
                entagua = false;
                wait = 0; 
            }
        }

        float h = Input.GetAxis("Horizontal");
        if (h == 0)
        {
            h = Input.GetAxis("HorizontalLR");
        }

        zorroR.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(zorroR.velocity.x, -maxspeed, maxspeed);
        zorroR.velocity = new Vector2(limitedSpeed, zorroR.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(escala, escala, escala);

        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-escala, escala, escala);
        }

        if (saltar)
        {
            zorroR.velocity = new Vector2(zorroR.velocity.x, 0);
            zorroR.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            audioPlayer.Stop();
            audioPlayer.clip = audiosalto;
            audioPlayer.Play();
            saltar = false;
            
        }
    }
    void OnBecameInvisible()
    {
        transform.position = new Vector3(1.5f, 3f, 0);
    }


     void OnCollisionStay2D(Collision2D col)
    {
        
        suelo = true;
        if (col.gameObject.tag == "Eagle")
        {
            suelo = false;
            spr.color = Color.red;
            herido = true;

        }
        if (col.gameObject.tag == "Enemy")
        {
            posX = col.gameObject.transform.position.x;
            suelo = false;
            spr.color = Color.red;
            herido = true;
            
            
        }
        if (col.gameObject.tag == "Agua")
        {
            suelo = false;
            
            spr.color = Color.cyan;
            herido = true;
            entagua = true;
            
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        suelo = false;
        if (col.gameObject.tag == "Eagle")
        {
            spr.color = Color.red;
            herido = false;

        }
        if (col.gameObject.tag == "Enemy")
        {
            
            spr.color = Color.red;
            herido = false;
            
        }
        if (col.gameObject.tag == "Agua")
        {
            
            spr.color = Color.cyan;
            herido = true;
            entagua = true;

            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Moneda")
        {
            numcoin = numcoin + 1;
            if (audioPlayer.clip == audiosalto)
            {
                audioPlayer.Stop();
            }
            audioPlayer.clip = audiomoneda;
            audioPlayer.Play();
            
            
        }  

    }
}
