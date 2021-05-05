using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovilNave : MonoBehaviour
{

    public Transform target;
    public float speed;
    private float x = 0.3f;
    private Vector3 start, end;

    // Use this for initialization
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if (transform.position == target.position)
        {
            target.position = (target.position == start) ? end : start;
            if(x > 0)
            {
                x = -0.3f;
                transform.localScale = new Vector3(x, 0.3f, 1f);
                
            }
            else
            {
                x = 0.3f;
                transform.localScale = new Vector3(x, 0.3f, 1f);
            }

                

        }
    }

}
