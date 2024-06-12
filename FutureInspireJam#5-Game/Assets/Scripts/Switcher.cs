using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [SerializeField] private SwitchersManager _switchersManager;
    [SerializeField] private bool _isCorrectSwitcher;
    private Animator _animator;
    private Material _deffaultMaterial;
    public bool _switched { get; private set; }

    void Start() 
    {
        _animator = GetComponent<Animator>();
        _deffaultMaterial = GetComponent<MeshRenderer>().materials[0];
    }

    public void Switch()
    {
        _switched = !_switched;
        _animator.SetBool("IsSwitched", _switched);

        if (_isCorrectSwitcher)
        {
            if (_switched)
            {
                _switchersManager.AddSwitcher();

                Material[] materials = new Material[1];
                materials[0] = _switchersManager.GetCorrectSwitcherMaterial();
                GetComponent<MeshRenderer>().materials = materials;
            }
            else
            {
                _switchersManager.RemoveSwitcher();

                Material[] materials = new Material[1];
                materials[0] = _deffaultMaterial;
                GetComponent<MeshRenderer>().materials = materials;
            }
        }
        else
        {
            if (_switched)
            {
                Material[] materials = new Material[1];
                materials[0] = _switchersManager.GetIncorrectSwitcherMaterial();
                GetComponent<MeshRenderer>().materials = materials;
            }
            else
            {
                Material[] materials = new Material[1];
                materials[0] = _deffaultMaterial;
                GetComponent<MeshRenderer>().materials = materials;
            }
        }
    }

    public bool IsCorrectSwitcher()
    {
        return _isCorrectSwitcher;
    }

    public SwitchersManager GetSwitchersManager()
    {
        return _switchersManager;
    }
}
