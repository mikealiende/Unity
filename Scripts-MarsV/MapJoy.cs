using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapJoy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MAPEADO DE BOTONES
        if (Input.GetButtonDown("X"))
        {
            print("Has pulsado X");
        }
        if (Input.GetButtonDown("A"))
        {  
            print("Has pulsado A");
        }
        if (Input.GetButtonDown("B"))
        {
            print("Has pulsado B");
        }
        if (Input.GetButtonDown("Y"))
        {
            print("Has pulsado Y");
        }
        if (Input.GetButtonDown("L1"))
        {
            print("Has pulsado L1");
        }
        if (Input.GetButtonDown("Select"))
        {
            print("Has pulsado Select");
        }
        if (Input.GetButtonDown("R1"))
        {
            print("Has pulsado R1");
        }
        if (Input.GetButtonDown("Start"))
        {
            print("Has pulsado Start");
        }

        if (Input.GetButtonDown("X1"))
        {
            print("Has pulsado X1");
        }
        if (Input.GetButtonDown("A1"))
        {
            print("Has pulsado A1");
        }
        if (Input.GetButtonDown("B1"))
        {
            print("Has pulsado B1");
        }
        if (Input.GetButtonDown("Y1"))
        {
            print("Has pulsado Y1");
        }
        if (Input.GetButtonDown("L11"))
        {
            print("Has pulsado L11");
        }
        if (Input.GetButtonDown("Select1"))
        {
            print("Has pulsado Select1");
        }
        if (Input.GetButtonDown("R11"))
        {
            print("Has pulsado R11");
        }
        if (Input.GetButtonDown("Start1"))
        {
            print("Has pulsado Start1");
        }

        //MAPEADO DE DPAC
        float digitalX = Input.GetAxis("Horizontal");
        float digitalY = Input.GetAxis("Vertical");

        if(digitalX != 0)
        {
            print("Valor D-Pad X = " + digitalX);
        }
        if (digitalY != 0)
        {
            print("Valor D-Pad Y = " + digitalY);
        }

        float digitalX1 = Input.GetAxis("Horizontal1");
        float digitalY1 = Input.GetAxis("Vertical1");

        if (digitalX1 != 0)
        {
            print("Valor D-Pad X1 = " + digitalX1);
        }
        if (digitalY1 != 0)
        {
            print("Valor D-Pad Yº = " + digitalY1);
        }
    }
}
