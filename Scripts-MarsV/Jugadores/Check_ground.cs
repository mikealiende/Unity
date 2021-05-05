using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_ground : MonoBehaviour
{

    private Rigidbody2D rb2d; //Para que cuando el caballero toca la plataforma la velocidad sea 0
    private Knight_control player;
    private Goku_control goku;
    // Start is called before the first frame update
    void Start()
    {
        goku = GetComponentInParent<Goku_control>();
        player = GetComponentInParent<Knight_control>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) //solo detecta cuando choca por primera vez
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            player.transform.parent = collision.transform;
            player.grounded = true;

            goku.transform.parent = collision.transform;
            goku.grounded = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.grounded = true;
            goku.grounded = true;
        }
        if (collision.gameObject.tag == "Plataforma")
        {
            player.transform.parent = collision.transform;
            player.grounded = true;

           goku.transform.parent = collision.transform;
            goku.grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            player.grounded = false;
            goku.grounded = false;
        }

        if (collision.gameObject.tag == "Plataforma")
        {
            player.transform.parent = null;
            player.grounded = false;

            goku.transform.parent = null;
            goku.grounded = false;
        }
    }
    
    
}
