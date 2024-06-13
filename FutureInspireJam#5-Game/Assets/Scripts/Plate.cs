using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private PlatesManager _platesManager;
    private bool _isPressed = false;

    void Start()
    {  
        Material[] materials = new Material[1];
        materials[0] = _platesManager.GetIncorrectSwitcherMaterial();
        GetComponent<MeshRenderer>().materials = materials;
    }

    void OnCollisionEnter(Collision other)
    {
        if (_isPressed)
            return;


        if (other.transform.tag == "Pickable")
        {
            _platesManager.ActivatePlate();
            _isPressed = true;

            Material[] materials = new Material[1];
            materials[0] = _platesManager.GetCorrectSwitcherMaterial();
            GetComponent<MeshRenderer>().materials = materials;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (!_isPressed)
            return;

        if (other.transform.tag == "Pickable")
        {
            _platesManager.DisactivePlate();
            _isPressed = false;

            Material[] materials = new Material[1];
            materials[0] = _platesManager.GetIncorrectSwitcherMaterial();
            GetComponent<MeshRenderer>().materials = materials;
        }
    }
}
