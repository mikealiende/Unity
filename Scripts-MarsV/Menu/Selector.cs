using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public GameObject caballero;
  

    // Start is called before the first frame update
    void Start()
    {
        caballero = GameObject.Find("Caballero");

    }

    // Update is called once per frame
    void Update()
    {

        caballero.gameObject.SetActive(Estado_juego.estado_juego.caballero);

    }
}
