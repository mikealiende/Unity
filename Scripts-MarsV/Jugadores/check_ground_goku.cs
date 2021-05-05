using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class check_ground_goku : MonoBehaviour
{
    // Start is called before the first frame update
    private Goku_control goku;
    private Rigidbody2D rb2d;

    void Start()
    {
        goku = GetComponentInParent<Goku_control>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) //solo detecta cuando choca por primera vez
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
           

            goku.transform.parent = collision.transform;
            goku.grounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
          
            goku.grounded = true;
        }
        if (collision.gameObject.tag == "Plataforma")
        {
            goku.transform.parent = collision.transform;
            goku.grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
           
            goku.grounded = false;
        }

        if (collision.gameObject.tag == "Plataforma")
        {
            

            goku.transform.parent = null;
            goku.grounded = false;
        }
    }
}
