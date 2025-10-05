using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject groundfloor; // It Stores the Prefabs of Ground,Obstacles and Collectbies.

    Vector3 nxtSpawnPoint; // Reference of next Positon Where we have to spawn the next Ground.
    public void Spawnfloor() // For Spawning the Floor.
    {
        GameObject temp = Instantiate(groundfloor, nxtSpawnPoint, Quaternion.identity); // It will take groundfloor, and spawn to the specific point.
        nxtSpawnPoint = temp.transform.GetChild(1).transform.position; // It will read the position of nextSpawnpoint from the unity scene.
    }

    public void Start() // It will spawn 10 floor at first start.
    {   for(int i = 0; i < 10; i++)
        {
            Spawnfloor();
        }
    }
}
