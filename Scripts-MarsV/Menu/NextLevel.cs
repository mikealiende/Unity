using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool entra = false;
    private void FixedUpdate()
    {
        if(entra == true)
        {
            if (SceneManager.GetActiveScene().name == "Zone4")
            {
                SceneManager.LoadScene("Winner");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //solo detecta cuando choca por primera vez
    {
        if (collision.gameObject.tag == "Player")
        {
            entra = true;
        }
    }
}
 

    