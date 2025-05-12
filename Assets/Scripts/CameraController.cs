using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // Asigna aquí el jugador
    public Vector3 offset = new Vector3(0, 5, -10); // Ajusta la distancia
    private PlayerController player;

    void Start(){
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<PlayerController>();
    }

    
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
    
}
