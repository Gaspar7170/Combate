using UnityEngine;
using System.Collections;
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    public int vida = 20;

    private PlayerController player;

    public GameObject corazonesRotos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0){
            Destroy(gameObject);
        }

    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AtaqueJugador"))
        {
            
            MostrarCorazon();
            vida -= 5;
            if (vida <= 0){
                Destroy(gameObject);
            }
            
            Knockback();
        }
    }
    void MostrarCorazon()
    {
        Vector3 posicionCorazon = transform.position + new Vector3(0, 3.5f, 0);
        GameObject corazon = Instantiate(corazonesRotos, posicionCorazon, Quaternion.identity);
        Destroy(corazon, 0.3f);  // Destruye el corazón después de 0.3 segundo
        return;
    }
    void Knockback(){

        if (transform.position.x < player.transform.position.x)
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
