using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
 
{
    // Start is called before the first frame update
    public Vector2 minCam, maxCam;
    public GameObject follow_caballero;
    public GameObject follow_goku;
    public float smoothTime; //para suavizar movimineto de camara

    private Vector2 velocity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Estado_juego.estado_juego.caballero)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, follow_caballero.transform.position.x, ref velocity.x, smoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y, follow_caballero.transform.position.y, ref velocity.y, smoothTime);

            transform.position = new Vector3(
            Mathf.Clamp(posX, minCam.x, maxCam.x),
            Mathf.Clamp(posY, minCam.y, maxCam.y), transform.position.z);
        }

        if (Estado_juego.estado_juego.goku)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, follow_goku.transform.position.x, ref velocity.x, smoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y, follow_goku.transform.position.y, ref velocity.y, smoothTime);

            transform.position = new Vector3(
            Mathf.Clamp(posX, minCam.x, maxCam.x),
            Mathf.Clamp(posY, minCam.y, maxCam.y), transform.position.z);
        }




    }
}
