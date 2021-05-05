using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Para crear las plataformas moviles

public class linea_escena : MonoBehaviour
{
    public Transform from;
    public Transform to;

    private void OnDrawGizmosSelected()
    {
       if(from != null && to != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, 0.35f);
            Gizmos.DrawSphere(to.position, 0.35f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
