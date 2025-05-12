using UnityEngine;
using System.Collections;

public class IASoldadoMelee : MonoBehaviour
{
    //Atributos Generales
    private Rigidbody2D rb;
    private PlayerController player;
    private float velocidad = 1.2f;

    //Atributos de SeguimientoIA
    public float radiodeteccion = 5.0f;

    //Atributos de PatrullaIA
    [SerializeField] private Transform[] puntosPatrulla;
    [SerializeField]private float tiempoEspera = 2f;
    private bool estaEsperando = false;
    private int puntoActual;

    //Atributos Compartidos
    private bool mirandoIzquierda = true;
    private bool enemigoDetectado = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            {
                // Si el jugador no está presente dejar de buscarlo
                seguirPlayer();
                if(!enemigoDetectado){
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
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidad * Time.deltaTime);
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


    //Seccion de Ataque
    void Atacar()
    {
        
        int numeroAleatorio = Random.Range(0, 6);
        posicionplayer = player.transform.position;



        if (mirandoIzquierda)
        {
            // Ataque desde la derecha
            
            Vector3 posicionAtaque = transform.position + new Vector3(1.3f, 0f, 0f);
            if(numeroAleatorio == 0){
                Instantiate(slash, posicionAtaque, Quaternion.Euler(0f,0f,0f));
            }
            else{
                Instantiate(thrust, posicionAtaque, Quaternion.Euler(0f,0f,0f));
            }
        }
        else
        {
            // Ataque desde la izquierda
            
            Vector3 posicionAtaque = transform.position + new Vector3(-1.3f, 0f, 0f);
            if(numeroAleatorio == 0){
                Instantiate(slash, posicionAtaque, Quaternion.Euler(0f,0f,180f));
            }
            else{
                Instantiate(thrust, posicionAtaque, Quaternion.Euler(0f,0f,180f));
            }
        }
    }

    void MostrarCorazon()
    {
        Vector3 posicionCorazon = transform.position + new Vector3(0, 3.5f, 0);
        GameObject corazon = Instantiate(corazonesRotos, posicionCorazon, Quaternion.identity);
        Destroy(corazon, 0.3f);  // Destruye el corazón después de 0.3 segundo
        return;
    }
    private IEnumerator Cooldown()
    {
        puedeRecibirGolpe = false;
        yield return new WaitForSeconds(espera);
        puedeRecibirGolpe = true;
        Atacar();
    }
    void Knockback(){

        posicionplayer = player.transform.position;
        if (transform.position.x < posicionplayer.x)
        {
            rb.AddForce(Vector2.left * 3f, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * 3f, ForceMode2D.Impulse);
        }
        rb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
    }



}
