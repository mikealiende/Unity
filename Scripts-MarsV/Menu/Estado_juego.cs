

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public class Estado_juego : MonoBehaviour
{
    public bool goku, caballero;

    private string rutaArchivo;

    public static Estado_juego estado_juego;

    void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/data.dat";

        if (estado_juego == null)
        {
            estado_juego = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (estado_juego != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cargar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activar_goku()
    {
        goku = true;
        caballero = false;
    }

    public void Activar_Caballero()
    {
        caballero = true;
        goku = false;
    }

    void Guardar()
    {       //Coger datos de la clase que neecesitmaos y guardarlos en un archivo
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(rutaArchivo);

        Datos datos = new Datos(goku,caballero);
        datos.caballero = caballero;
        datos.goku = goku;

        bf.Serialize(file, datos);
        file.Close();
    }

    void Cargar() {
        //Coger el archivo de antes y deserializar los datos
        if (File.Exists(rutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);

            Datos datos = (Datos)bf.Deserialize(file);

            //actualizamos nuestras variables a lo que hay en el archivo
            caballero = datos.caballero;
            goku = datos.goku;

            file.Close();
        }
        else
        {
            goku = false;
            caballero = false;
        }
    }

 }

    [Serializable]
    class Datos
    {
        public bool goku;
        public bool caballero;
       
        public Datos (bool goku, bool caballero)
        { 
            this.goku = goku;
            this.caballero = caballero;
        }
    }

