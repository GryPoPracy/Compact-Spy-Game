using BaseGameLogic.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationSettings : MonoBehaviour
{
    [SerializeField] private Vector2Int _startLevelSize = new Vector2Int(10, 10);
    public Vector2Int StartLevelSize { get { return _startLevelSize; } }

    [SerializeField] private List<GameObject> _levelPrefabBoxList = new List<GameObject>();
    [SerializeField] private List<GameObject> _levelPrefabBoxLeftEdgeList = new List<GameObject>();
    [SerializeField] private List<GameObject> _levelPrefabBoxRightEdgeList = new List<GameObject>();
    [Space][SerializeField] private int _startFlorIndex = 1;
    public int StartFlorIndex { get { return _startFlorIndex; } }
    [SerializeField] private List<GameObject> _enemyPrefabList = new List<GameObject>();
    [SerializeField, Range(0f, 1f)] private float _ennemySpawnChance = .8f;
    public float EnnemySpawnChance { get { return _ennemySpawnChance; } }

    private ListRandomSelektor _levelBoxSelector = null;
    private ListRandomSelektor _levelBoxxLeftEdgeSelector = null;
    private ListRandomSelektor _levelBoxRightEdgeSelector = null;
    private ListRandomSelektor _enemyPrefabListSelector = null;

    public GameObject LevelBoxInstance {  get { return Instantiate(_levelBoxSelector.Select() as GameObject); } }
    public GameObject LevelBoxLeftEdgeInstance { get { return Instantiate(_levelBoxxLeftEdgeSelector.Select() as GameObject); } }
    public GameObject LevelBoxRightEdgeInstance { get { return Instantiate(_levelBoxRightEdgeSelector.Select() as GameObject); } }
    public GameObject EnemyInstance { get { return Instantiate(_enemyPrefabListSelector.Select() as GameObject); } }

    [SerializeField] private List<GameObject> _staircasePrefabList = new List<GameObject>();
    private ListRandomSelektor _stairCaseSelector = null;
    public GameObject StarCaseInstance { get { return Instantiate(_stairCaseSelector.Select() as GameObject); } }

    [SerializeField] private float _groundLevel = .1f;
    public float GroundLevel { get { return _groundLevel; } }

    [SerializeField] private GameObject _playerObject = null;
    public GameObject PlayerObject { get { return _playerObject; } }

    [SerializeField] private GameObject _cameraObject = null;
    public GameObject CameraObject { get { return _cameraObject; } }

    [SerializeField] private List<GameObject> _objectsToSpanw = new List<GameObject>();
    public List<GameObject> ObjectsToSpanw { get { return _objectsToSpanw; } }


    private void Awake()
    {
        _levelBoxSelector = new ListRandomSelektor(_levelPrefabBoxList);
        _stairCaseSelector = new ListRandomSelektor(_staircasePrefabList);
        _levelBoxxLeftEdgeSelector = new ListRandomSelektor(_levelPrefabBoxLeftEdgeList);
        _levelBoxRightEdgeSelector = new ListRandomSelektor(_levelPrefabBoxRightEdgeList);
        _enemyPrefabListSelector = new ListRandomSelektor(_enemyPrefabList);
    }
}
