using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationSettings : MonoBehaviour
{
    [SerializeField] private Vector2Int _startLevelSize = new Vector2Int(10, 10);
    public Vector2Int StartLevelSize { get { return _startLevelSize; } }

    [SerializeField] private List<GameObject> _levelPrefabBoxList = new List<GameObject>();
    public GameObject LevelBoxInstance {  get { return Instantiate(_levelPrefabBoxList[Random.Range(0, _levelPrefabBoxList.Count)]); } }

    [SerializeField] private List<GameObject> _staircasePrefabList = new List<GameObject>();
    public GameObject StarCaseInstance { get { return Instantiate(_staircasePrefabList[Random.Range(0, _staircasePrefabList.Count)]); } }

    [SerializeField] private float _groundLevel = .1f;
    public float GroundLevel { get { return _groundLevel; } }

    [SerializeField] private GameObject _playerObject = null;
    public GameObject PlayerObject { get { return _playerObject; } }

    [SerializeField] private GameObject _cameraObject = null;
    public GameObject CameraObject { get { return _cameraObject; } }
}
