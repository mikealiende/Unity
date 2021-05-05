using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausa : MonoBehaviour
{

    bool active = false;
    Canvas canvas;
    public AudioSource audio1;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start")|| Input.GetKeyDown("p"))
        {
            active = !active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
            if(active) audio1.Pause();
            else audio1.UnPause();
        }
        
    }
}
