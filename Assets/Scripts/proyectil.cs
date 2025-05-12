using UnityEngine;

public class proyectil : MonoBehaviour
{
    [SerializeField]private float velocidad = 5f;

    private PlayerController player;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
        }
        
        ArrojarProyectil();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ArrojarProyectil(){
        Vector2 direccion = (player.transform.position - transform.position).normalized;

        rb.linearVelocity = direccion * velocidad;
        // Destruir el proyectil después de 10 segundos
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.vida -= 5;
            Destroy(gameObject);
        }
    }
}
