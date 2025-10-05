using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0); // For Coin Rotation
    }
}
