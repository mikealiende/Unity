using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_vida : MonoBehaviour
{
    public float vida;
    private Animator anim2;
    Rigidbody2D vidaR;
    // Start is called before the first frame update
    void Start()
    {
        vidaR = GetComponent<Rigidbody2D>();
        anim2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        anim2.SetFloat("num", vida);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("entrando");
            print(vida);
            vida++;

        }
        else
        {
            vida = vida + 0;
        }

    }
}