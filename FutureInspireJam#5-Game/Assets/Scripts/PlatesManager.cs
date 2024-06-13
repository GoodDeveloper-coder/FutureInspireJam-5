using UnityEngine;

public class PlatesManager : MonoBehaviour
{
    [SerializeField] private Door _doorToNextLevel;
    [SerializeField] private int _platesToNextLevel;

    [Header(" ")]
    [SerializeField] private Material _correctSwitcherMaterial;
    [SerializeField] private Material _incorrectSwitcherMaterial;
    private int _activePlates;

    public void ActivatePlate()
    {
        _activePlates++;

        if (_activePlates >= _platesToNextLevel)
            LevelsManager.instance.NextLevel();
        else
            _doorToNextLevel.EnableIndicator();
    }

    public void DisactivePlate()
    {
        _activePlates--;
        _doorToNextLevel.DisableIndicator();
    }

    public Material GetCorrectSwitcherMaterial()
    {
        return _correctSwitcherMaterial;
    }

    public Material GetIncorrectSwitcherMaterial()
    {
        return _incorrectSwitcherMaterial;
    }
}
