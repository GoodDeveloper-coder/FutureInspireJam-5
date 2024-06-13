using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private Transform _playerRespawnPos;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            other.transform.position = _playerRespawnPos.position;
    }
}
