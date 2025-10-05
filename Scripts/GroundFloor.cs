using UnityEngine;

public class GroundFloor : MonoBehaviour
{
    Spawn groundSpawner; // Var to store the Spawn Script.

    void Start()
    {
        groundSpawner = GameObject.FindFirstObjectByType<Spawn>(); // It will find Spawn Script and Save it to groundspawner var.
    }
    private void OnTriggerExit(Collider other) // Run when player leaves the Trigger zone.
    {
        if (other.CompareTag("Player")) // Check if the player leaves.
        {
            groundSpawner.Spawnfloor(); // Spawn next Ground Floor 
        }
        Destroy(gameObject, 2); // It will wait for 2 seconds and destroy old floor.
    }
}
