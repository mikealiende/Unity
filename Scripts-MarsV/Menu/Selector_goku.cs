
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector_goku : MonoBehaviour
{

    public GameObject goku;
    // Start is called before the first frame update
    void Start()
    {
        goku = GameObject.Find("Goku");
    }

    // Update is called once per frame
    void Update()
    {
        goku.gameObject.SetActive(Estado_juego.estado_juego.goku);
    }
}
