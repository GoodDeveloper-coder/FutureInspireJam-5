using TMPro;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 8;
    [SerializeField] private GameObject _interactText;
    [SerializeField] private GameObject _pickUpText;
    private GameObject _pickedGameObject;
    private int _switchedSwitchers = 0;
    private Switcher _lastSwitcher;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2 , Camera.main.pixelHeight / 2, 0));
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
            {
                if (hit.transform.tag == "Pickable")
                {
                    if (_pickedGameObject == null)
                    {
                        _pickedGameObject = hit.transform.gameObject;
                        _pickedGameObject.transform.SetParent(transform);
                
                        if (_pickedGameObject.TryGetComponent<Collider>(out Collider collider))
                            collider.enabled = false;

                        if (_pickedGameObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                        {
                            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
                if (hit.transform.tag == "Switcher")
                {
                    Switcher switcher = hit.transform.GetComponent<Switcher>();
                    switcher.Switch();
                    if (switcher.IsCorrectSwitcher())
                    {
                        if (_lastSwitcher != null)
                            if (!_lastSwitcher.IsCorrectSwitcher())
                            {
                                switcher.GetSwitchersManager().UnSwitchAllSwitchers();
                                _switchedSwitchers = 0;
                            }
                            else
                                _switchedSwitchers++;
                        else
                            _switchedSwitchers++;

                        _lastSwitcher = switcher;
                    }
                    else
                    {
                        _lastSwitcher = switcher;
                        _switchedSwitchers++;
                        if (_switchedSwitchers >= 2)
                        {
                            switcher.GetSwitchersManager().UnSwitchAllSwitchers();
                            _switchedSwitchers = 0;
                        }
                    }

                }

        if (Physics.Raycast(ray, out RaycastHit test, _maxDistance))
        {
            if (test.transform.tag == "Switcher")
            {
                _interactText.SetActive(true);
                _pickUpText.SetActive(false);
            }
            else if (test.transform.tag == "Pickable")
            {
                if (_pickedGameObject == null)
                    _pickUpText.SetActive(true);
                else
                    _pickUpText.SetActive(false);

                _interactText.SetActive(false);
            }
        }
        else
        {
            _pickUpText.SetActive(false);
            _interactText.SetActive(false);
        }

        if (Input.GetMouseButtonUp(0))
            if (_pickedGameObject != null)
            {
                _pickedGameObject.transform.parent = null;
                if (_pickedGameObject.TryGetComponent<Collider>(out Collider collider))
                    collider.enabled = true;

                if (_pickedGameObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    rigidbody.constraints = RigidbodyConstraints.None;
                }
                _pickedGameObject = null;
            }
    }
}
