using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.SceneManagement;


public class volver_menu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Volver_menu(string Nombre_escena)
    {
        SceneManager.LoadScene(Nombre_escena);
       
        //Estado_juego.estado_juego.caballero = false;
        //Estado_juego.estado_juego.goku = false;
        Estado_juego.estado_juego = null;
        Time.timeScale = (false) ? 0 : 1f;

    }
}
