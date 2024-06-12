using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _doors;
    [SerializeField] private int _currentLevel = 1;

    public static LevelsManager instance;

    void Start()
    {
        instance = this;
    }

    public void NextLevel()
    {
        _doors[_currentLevel - 1].transform.DOMoveY(_doors[_currentLevel - 1].transform.position.y + 4f, 3);
        _currentLevel++;
    }
}
