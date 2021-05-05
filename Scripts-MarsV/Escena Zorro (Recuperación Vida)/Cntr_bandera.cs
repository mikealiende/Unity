using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cntr_bandera : MonoBehaviour
{
    // Start is called before the first frame update
    public zorroplayer scriptjugador;
    private int monedas = 0;
    private int enemigos = 0;
    string escena;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnEnable();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            enemigos = scriptjugador.numenemy;
            monedas = scriptjugador.numcoin;
            print(escena);
            if(monedas == 6 && enemigos == 1){
                //CAMBIO DE ESCENA HAS GANADO
                SceneManager.LoadScene(escena);
            }
        }
    }

    void OnEnable()
    {
        escena = PlayerPrefs.GetString("scene");
    }
}
