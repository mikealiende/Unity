using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr_vidas : MonoBehaviour
{
    public zorroplayer scriptzorro;
    private Animator anim2;
    public int vidas;
    // Start is called before the first frame update
    void Start()
    {
        anim2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vidas = scriptzorro.numcoin;
        
    }
    void FixedUpdate()
    {
        anim2.SetInteger("cont", vidas);

    }
}
