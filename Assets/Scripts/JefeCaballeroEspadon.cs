using UnityEngine;

public class JefeCaballeroEspadon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //---------------Seccion de Variables---------------//
    public bool mirandoIzquierda = true;

    //---------------Seccion de Tipos de Ataques---------------//
    public GameObject slash;
    public GameObject estocada;
    public GameObject reflejo;
    public GameObject pisoton;
    public GameObject gritoBatalla;
    public GameObject carga;
    public GameObject risa;

    //----------------Fin Seccion de Tipos de Ataques---------------//


     //---------------Seccion de Ataque---------------//
    //caballero el cual va a ser el jefe de los demas, este debe de usar un espadon.
    // el primer movimiento debera de poner su espada en alto y golpear hacia abajo,
    // el segundo movimiento debe de poner su espada hacia atras para asi cargar una estocada, 
    // el tercer movimiento es un ataque hacia su espalda saliendo desde el suelo hasta atras de el mismo por arriba de su cabeza, 
    // el cuarto movimiento debera ser un pisoton al suelo, 
    // el quinto movimiento debera ser un grito de batalla, 
    // el sexto movimiento debera de ser una carga con el hombro, 
    // el septimo movimiento debera ser que el enemigo se ria.
    void Atacar()
    {
        
        int ataqueElegido = Random.Range(1, 7);



        if (!mirandoIzquierda)
        {
            // Ataque desde la derecha
            switch (ataqueElegido)
        {
            case 1:
                Slash(1);
                break;
            case 2:
                Estocada(1);
                break;
            case 3:
                Reflejo(1);
                break;
            case 4:
                Pisoton(1);
                break;
            case 5:
                GritoBatalla(1);
                break;
            case 6:
                Carga(1);
                break;
            case 7:
                Risa(1);
                break;
        }

        }
        else
        {
            // Ataque desde la izquierda
            
            //Vector3 posicionAtaque = transform.position + new Vector3(-1.3f, 0f, 0f);
            switch (ataqueElegido)
        {
            case 1:
                Slash(-1);
                break;
            case 2:
                Estocada(-1);
                break;
            case 3:
                Reflejo(-1);
                break;
            case 4:
                Pisoton(-1);
                break;
            case 5:
                GritoBatalla(-1);
                break;
            case 6:
                Carga(-1);
                break;
            case 7:
                Risa(-1);
                break;
        }
        }
    }

    //Ataques
    //Ataque 1 (barrido):
    //Instantiate(slash, posicionAtaque, Quaternion.Euler(0f,0f,0f));
    void Slash(int direccion){
        
        if(direccion == 1)
        {
            Instantiate(slash, transform.position * direccion, Quaternion.Euler(0f,0f,0f));
        } 
        else 
        {
            Instantiate(slash, transform.position * direccion, Quaternion.Euler(0f,0f,180f));
        }
    }
    //Ataque 2 (estocada):
    void Estocada(int direccion){
        if (direccion == 1)
        {
            Instantiate(estocada, transform.position * direccion, Quaternion.Euler(0f,0f,0f));
        }
        else
        {
            Instantiate(estocada, transform.position * direccion, Quaternion.Euler(0f,0f,180f));
        }
    }
    //Ataque 3 (Reflejo):
    void Reflejo(int direccion){
        if (direccion == 1)
        {
            Instantiate(reflejo, transform.position * direccion, Quaternion.Euler(0f,0f,0f));
        }
        else
        {
            Instantiate(reflejo, transform.position * direccion, Quaternion.Euler(0f,0f,180f));
        }
    }
    //Ataque 4 (Pisoton):
    void Pisoton(int direccion){
        if (direccion == 1)
        {
            Instantiate(pisoton, transform.position * direccion, Quaternion.Euler(0f,0f,0f));
        }
        else
        {
            Instantiate(pisoton, transform.position * direccion, Quaternion.Euler(0f,0f,180f));
        }
    }
    //Ataque 5 (Grito de batalla):
    void GritoBatalla(int direccion){
        if (direccion == 1)
        {
            Instantiate(gritoBatalla, transform.position * direccion, Quaternion.Euler(0f,0f,0f));
        }
        else
        {
            Instantiate(gritoBatalla, transform.position * direccion, Quaternion.Euler(0f,0f,180f));
        }
    }
    //Ataque 6 (Carga):
    void Carga(int direccion){
        if (direccion == 1)
        {
            Instantiate(carga, transform.position * direccion, Quaternion.Euler(0f,0f,0f));
        }
        else
        {
            Instantiate(carga, transform.position * direccion, Quaternion.Euler(0f,0f,180f));
        }
    }
    //Ataque 7 (Risa):
    void Risa(int direccion){
        if (direccion == 1)
        {
            Instantiate(risa, transform.position * direccion, Quaternion.Euler(0f,0f,0f));
        }
        else
        {
            Instantiate(risa, transform.position * direccion, Quaternion.Euler(0f,0f,180f));
        }
    }
    //---------------Fin de la Seccion de Ataque---------------//
    //---------------Seccion de Daño---------------//
    //En esta seccion el jefe debera de recibir daño, al recibir daño el jefe debera de bajar la barra de vida.







}
