using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private PlatesManager _platesManager;
    private bool _isPressed = false;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Pickable")
        {
            _platesManager.ActivatePlate();
            _isPressed = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Pickable")
        {
            _platesManager.DisactivePlate();
            _isPressed = false;
        }
    }
}
