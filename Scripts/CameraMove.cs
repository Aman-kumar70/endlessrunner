using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player; //Camera to follow the Player
    private Vector3 offset; // Var for Distance B/w Player and Camera

    void Start()
    {
        offset = transform.position - player.transform.position; // Gap b/w the camera and player
    }

   
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; // For Camera Position 
    }
}
