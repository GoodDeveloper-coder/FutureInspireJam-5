using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private List<GameObject> _correctSwitchedIndicators;

    public void EnableIndicator()
    {
        foreach (GameObject indicator in _correctSwitchedIndicators)
            if (!indicator.activeSelf)
            {
                indicator.SetActive(true);
                break;
            }
    }

    public void DisableIndicator()
    {
        for (int i = _correctSwitchedIndicators.Count - 1; i > 0; i--)
            if (_correctSwitchedIndicators[i].activeSelf)
            {
                _correctSwitchedIndicators[i].SetActive(false);
                break;
            }
    }

    public void DisableAllIndicators()
    {
        for (int i = _correctSwitchedIndicators.Count - 1; i > 0; i--)
            if (_correctSwitchedIndicators[i].activeSelf)
            {
                _correctSwitchedIndicators[i].SetActive(false);
            }
    }
}
