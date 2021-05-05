using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques_Goku : MonoBehaviour
{

    public Transform target_ataque;
    private Vector3 start, end;
    public float kame_spedd;
    public Goku_control goku;
    public kamekameha kamekameha;
    // Start is called before the first frame update         

    void Start()
    {

        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        
    }
   public void Update()
   {
        if (kamekameha.kamekame)
        {
            Invoke("Dispara", 0.3f);
        }
   }
    public void Dispara()
    {
        end = target_ataque.position;
        float FixedSpeed = kame_spedd * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, end, FixedSpeed);
        Invoke("Vuelta", 0.5f);             
    }

     public void Vuelta()
     {
        start = goku.transform.position;
        float FixedSpeed = kame_spedd * Time.deltaTime*5;
        transform.position = Vector3.MoveTowards(transform.position,start, FixedSpeed);
     }
}
