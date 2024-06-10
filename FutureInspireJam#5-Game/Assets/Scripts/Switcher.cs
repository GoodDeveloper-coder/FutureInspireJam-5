using System.Xml.Serialization;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [SerializeField] private SwitchersManager _switchersManager;
    [SerializeField] private bool _isCorrectSwitcher;
    private Animator _animator;
    public bool _switched { get; private set; }

    void Start() => _animator = GetComponent<Animator>();

    public void Switch()
    {
        _switched = !_switched;
        _animator.SetBool("IsSwitched", _switched);

        if (_isCorrectSwitcher)
        {
            if (_switched)
                _switchersManager.AddSwitcher();
            else
                _switchersManager.RemoveSwitcher();
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
