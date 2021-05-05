using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_movil : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool ok = false;
    private Vector3 start, end;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position; //coordenadas del principio transfrom.position es la posicion actual de la plataforma
            end = target.position; //coordenaddas del final
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            float FixedSpeed = speed * Time.deltaTime; //Necesitamos hacer esto para meter la veloicad en MoveTowards
            //a MoveTowards se le pasan 3 valores: punto actual donde estamos, obejtivo a donde vamos
            //y la velocidad
            transform.position = Vector3.MoveTowards(transform.position, target.position, FixedSpeed);
        }

        if (transform.position == target.position)
        {
            target.position = (target.position == start) ? end : start; //si la posicion actual vale start, 
            ok = true;                                                            //el target se va al fianl y viveversa



        }
    }
}
