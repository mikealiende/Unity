using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctl_vidasHistoria : MonoBehaviour
{
    // Start is called before the first frame update
    public Goku_control scriptgoku;
    public Knight_control scriptknight;
    public GameObject follow;
    public Vector2 minCamPos, maxCamPos;
    public float difX;
    public float difY;

    private Animator anim2;
    public int vidas;

    void Start()
    {
        anim2 = GetComponent<Animator>();
        difX = Mathf.Abs(transform.position.x) - Mathf.Abs(follow.transform.position.x);
        difY = Mathf.Abs(transform.position.y) - Mathf.Abs(follow.transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {   
        if (Estado_juego.estado_juego.goku)
        {
            vidas = scriptgoku.vidas;
        }

        if (Estado_juego.estado_juego.caballero)
        {
            vidas = scriptknight.vidas;
        }


    }
    void FixedUpdate()
    {
        anim2.SetInteger("life", vidas);
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;

        transform.position = new Vector3(posX - Mathf.Abs(difX), posY + Mathf.Abs(difY), transform.position.z);

    }
}
