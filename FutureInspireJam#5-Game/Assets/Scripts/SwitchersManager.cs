using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchersManager : MonoBehaviour
{
    [SerializeField] private int _switchersToNextLevel = 3;
    [SerializeField] private Door _doorToNextLevel;
    [SerializeField] private List<GameObject> _switchedIndicators;

    [Header(" ")]
    [SerializeField] private Material _correctSwitcherMaterial;
    [SerializeField] private Material _incorrectSwitcherMaterial;

    private int _correctSwitched = 0;

    void Start()
    {
        // foreach (GameObject switcher in _switchedIndicators)
        //     if (switcher.GetComponent<Switcher>().IsCorrectSwitcher())
        //         _correctSwitchedIndicators.Add(switcher);
    }

    public void AddSwitcher()
    {
        _correctSwitched++;
        _doorToNextLevel.EnableIndicator();

        if (_correctSwitched == _switchersToNextLevel)
            LevelsManager.instance.NextLevel();
    }

    public void RemoveSwitcher()
    {
        _correctSwitched--;
        _doorToNextLevel.DisableIndicator();
    }

    
    public void UnSwitchAllSwitchers()
    {
        foreach (GameObject switcher in _switchedIndicators)
            if (switcher.GetComponent<Switcher>()._switched)
                switcher.GetComponent<Switcher>().Switch();

        _doorToNextLevel.DisableAllIndicators();
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
