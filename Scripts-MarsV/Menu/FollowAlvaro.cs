using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAlvaro : MonoBehaviour
{
    public Transform objetivo;
    public float smoothTime = 5;

    Vector3 desfase;

    // Start is called before the first frame update
    void Start()
    {
        desfase = transform.position - objetivo.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionObjetivo = objetivo.position + desfase;
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, smoothTime * Time.deltaTime);
    }
}
