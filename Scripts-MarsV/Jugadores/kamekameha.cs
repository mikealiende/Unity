using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamekameha : MonoBehaviour

{
    // Start is called before the first frame update
    public bool kamekame;
    

    private Animator anim;
    
    //public Goku_control goku;

   
    
    void Start()
    {
        anim = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Kamekameha", kamekame);
      
        if (kamekame)
        {  
           
            Invoke("Fin_kamekame", 0.3f);
        }   
    }

    void Fin_kamekame()
    {
        kamekame = false;
    }
}
