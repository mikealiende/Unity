using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr_eagle : MonoBehaviour
{
    public float maxspeed = 1f;
    public float speed = 1f;

    public Transform from;
    public Transform to;
    public Transform target;
    private Vector3 startplat;
    private Vector3 startarget;
    Rigidbody2D eagleR;

    void OnDrawGizmosSelected()
    {
        if (from != null && to != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(from.position, to.position);
            
        }
    }
    void Start()
    {
        if (target != null)
        {
            target.parent = null; // hacemos que no sea hijo de la plataforma y sea independiente.
        }
        eagleR = GetComponent<Rigidbody2D>();
        startplat = transform.position;
        startarget = target.position;
        transform.localScale = new Vector3(-1f, 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null) //Para estar seguro de que lo hemos asignado.
        {
            float fixedspeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedspeed); //posicion actual, donde queremos ir, speed.
            
        }

        if (transform.position == target.position)
        {
            if(target.position == startplat){
                target.position = startarget;
                transform.localScale = new Vector3(-1f, 1, 1);
            }
            else {
                target.position = startplat;
                transform.localScale = new Vector3(1f, 1, 1);
            }
            
        }
        
        

    }
}
