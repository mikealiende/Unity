using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cont_num_rana : MonoBehaviour
{
    // Start is called before the first frame update
    public Cntr_rana scriptrana;
    private Animator anim2;
    public int enem;
    void Start()
    {
        anim2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enem = scriptrana.num_rana;
    }
    void FixedUpdate()
    {
        anim2.SetInteger("cont_enemy", enem);

    }
}
