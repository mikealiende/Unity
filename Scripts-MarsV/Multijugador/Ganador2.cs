using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganador2 : MonoBehaviour
{
    public bool gana1 = false;
    public bool gana2 = false;
    private void FixedUpdate()
    {
        if (gana1 == true)
        {
            gana1 = false;
            SceneManager.LoadSceneAsync("G11");
        }
        if (gana2 == true)
        {
            gana2 = false;
            SceneManager.LoadSceneAsync("G22");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //solo detecta cuando choca por primera vez
    {
        if (collision.gameObject.tag == "Player")
        {
            gana1 = true;
        }
        if (collision.gameObject.tag == "Player2")
        {
            gana2 = true;
        }
    }
}
