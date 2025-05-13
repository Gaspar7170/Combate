using UnityEngine;
using System.Collections;

public class IASoldadoMelee : MonoBehaviour
{
    //Atributos Generales
    private Rigidbody2D rb;
    private PlayerController player;
    private float velocidad = 1.7f;

    //Atributos de SeguimientoIA
    public float radiodeteccion = 5.0f;

    //Atributos de PatrullaIA
    [SerializeField] private Transform[] puntosPatrulla;
    [SerializeField]private float tiempoEspera = 2f;
    private bool estaEsperando = false;
    private int puntoActual;
    private float espera = 3f;

    //Atributos Compartidos
    private bool mirandoIzquierda = true;
    private bool enemigoDetectado = false;

    //Atributos Ataque
    
    private bool atacando = false;

    //Ataques Gameobjects
    public GameObject slash;
    public GameObject estocada;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
        }
        if (transform.rotation.y == 0){mirandoIzquierda = false;}
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            {
                // Si el jugador no está presente dejar de buscarlo
                seguirPlayer();
                if(!enemigoDetectado && puntosPatrulla.Length > 0){
                    if(transform.position.x != puntosPatrulla[puntoActual].position.x){
                        VerificarDireccionRespectoAlLaPatrulla();
                        transform.position = Vector2.MoveTowards(transform.position, puntosPatrulla[puntoActual].position, velocidad * Time.deltaTime);
                    }
                    else if(!estaEsperando){StartCoroutine(Wait());}
                }
            }
    }

    //Seccion de SEGUIMIENTO AL JUGADOR

    void seguirPlayer(){
        
        float distanciaJugador = Vector2.Distance(transform.position, player.transform.position);
        if (distanciaJugador < radiodeteccion){
            VerificarDireccionRespectoAlJugador();
            enemigoDetectado = true;
            if (distanciaJugador < 1.8f){
                StartCoroutine(Cooldown());
            }
            if(!atacando)
            {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidad * Time.deltaTime);
            }
            
        }
        else{
            enemigoDetectado = false;
        }
        
        

    }
    

    //Seccion de patrulla
    
    IEnumerator Wait(){
        estaEsperando = true;
        Debug.Log("Esperando");
        yield return new WaitForSeconds(tiempoEspera);
        //Si el enemigo ha llegado al punto de patrulla, cambia al siguiente
        puntoActual++;
        //Si el enemigo ha llegado al final de los puntos de patrulla, vuelve al primero
        if(puntoActual >= puntosPatrulla.Length){
            puntoActual = 0;
        }
        estaEsperando = false;
        VerificarDireccionRespectoAlLaPatrulla();
    }

    


    //---------------Seccion de Ataque---------------//
    
    void Atacar()
    {
        
        int ataqueElegido = Random.Range(1, 2);



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
        }

        }
        else
        {
            // Ataque desde la izquierda
            
            
            switch (ataqueElegido)
        {
            case 1:
                Slash(-1);
                break;
            case 2:
                Estocada(-1);
                break;
        }
        }
    }

    //Ataques
    //Ataque 1 (barrido):
    //Instantiate(slash, posicionAtaque, Quaternion.Euler(0f,0f,0f));
    void Slash(int direccion){

        Vector3 posicionAtaque = transform.position + new Vector3(direccion, 0f, 0f);
        if(direccion == 1)
        {
            
            Instantiate(slash, posicionAtaque, Quaternion.Euler(0f,0f,0f));
        } 
        else 
        {
            Instantiate(slash, posicionAtaque, Quaternion.Euler(0f,0f,180f));
        }
    }
    //Ataque 2 (estocada):
    void Estocada(int direccion){
        Vector3 posicionAtaque = transform.position + new Vector3(direccion, 0f, 0f);
        if (direccion == 1)
        {
            Instantiate(estocada, transform.position * direccion, Quaternion.Euler(0f,0f,0f));
        }
        else
        {
            Instantiate(estocada, transform.position * direccion, Quaternion.Euler(0f,0f,180f));
        }
    }

    //Funciones varias utilizadas

    void VerificarDireccionRespectoAlLaPatrulla(){
        if (puntosPatrulla[puntoActual].transform.position.x > transform.position.x && mirandoIzquierda){Flip(); mirandoIzquierda = false;}
        if (puntosPatrulla[puntoActual].transform.position.x < transform.position.x && !mirandoIzquierda){Flip(); mirandoIzquierda = true;}
    }

    void VerificarDireccionRespectoAlJugador(){
        //Jugador a la derecha del enemigo
        if (player.transform.position.x > transform.position.x && mirandoIzquierda){Flip(); mirandoIzquierda = false;}
        //Jugador a la izquierda del enemigo
        if (player.transform.position.x < transform.position.x && !mirandoIzquierda){Flip(); mirandoIzquierda = true;}
    }

    void Flip(){
        // Cambia la escala en el eje X, lo que invierte el sprite visualmente
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    
    private IEnumerator Cooldown()
    {
        if (!atacando){
        atacando = true;
        Atacar();
        yield return new WaitForSeconds(espera);
        atacando = false;
        }
    }
    
    



}
