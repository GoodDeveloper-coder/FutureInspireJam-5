using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchersManager : MonoBehaviour
{
    [SerializeField] private int _switchersToNextLevel = 3;
    [SerializeField] private GameObject _doorToNextLevel;
    [SerializeField] private List<GameObject> _switchedIndicators;
    [SerializeField] private List<GameObject> _correctSwitchedIndicators = new List<GameObject>();
    private int _correctSwitched = 0;

    void Start()
    {
        // foreach (GameObject switcher in _switchedIndicators)
        //     if (switcher.GetComponent<Switcher>().IsCorrectSwitcher())
        //         _correctSwitchedIndicators.Add(switcher);
    }

    public void AddSwitcher()
    {
        _correctSwitchedIndicators[_correctSwitched++].SetActive(true);

        if (_correctSwitched == _switchersToNextLevel)
           _doorToNextLevel.transform.DOMoveY(_doorToNextLevel.transform.position.y + 4f, 3);
    }

    public void RemoveSwitcher()
    {
       _correctSwitchedIndicators[--_correctSwitched].SetActive(false);
    }

    
    public void UnSwitchAllSwitchers()
    {
        foreach (GameObject switcher in _switchedIndicators)
            if (switcher.GetComponent<Switcher>()._switched)
                switcher.GetComponent<Switcher>().Switch();
    }
}
