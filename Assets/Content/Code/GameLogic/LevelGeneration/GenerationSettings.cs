using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationSettings : MonoBehaviour
{
    [SerializeField] private Vector2Int _startLevelSize = new Vector2Int(10, 10);
    public Vector2Int StartLevelSize { get { return _startLevelSize; } }

    [SerializeField] private List<GameObject> _levelPrefabBoxList = new List<GameObject>();
    public List<GameObject> LevelPrefabBoxList { get { return _levelPrefabBoxList; } }

    [SerializeField] private int _levelBoxSize = 2;
    public int LevelBoxSize { get { return _levelBoxSize; } }
}
