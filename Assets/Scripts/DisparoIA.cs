using UnityEngine;
using System.Collections;
public class DisparoIA : MonoBehaviour
{
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float tiempoEntreDisparos = 2f;
    private PlayerController player;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
        }
        StartCoroutine(Disparar());
    }

    IEnumerator Disparar(){
        while (true)
        {
            // Esperar un tiempo antes de disparar
            yield return new WaitForSeconds(tiempoEntreDisparos);
            if (player == null)
            {
                // Si el jugador no esta presente, salir del bucle
                yield break;
            }
            
            // Instanciar el proyectil
            if (player.transform.position.x < transform.position.x - 5)
            {
            Instantiate(proyectilPrefab, transform.position, Quaternion.Euler(-3, 0, 0));
            }
            if (player.transform.position.x > transform.position.x + 5)
            {
                Instantiate(proyectilPrefab, transform.position, Quaternion.Euler(3, 0, 180));
            }
            
        }
    }
        
}
