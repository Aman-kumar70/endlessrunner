using UnityEngine;

public class GroundFloor : MonoBehaviour
{
    Spawn groundSpawner; // Var to store the Spawn Script.

    void Start()
    {
        groundSpawner = GameObject.FindFirstObjectByType<Spawn>();
    }
    private void OnTriggerExit(Collider other) // Run when player leaves the Trigger zone.
    {
        if (other.CompareTag("Player"))
        {
            groundSpawner.Spawnfloor(); 
        }
        Destroy(gameObject, 2); 
    }
}

