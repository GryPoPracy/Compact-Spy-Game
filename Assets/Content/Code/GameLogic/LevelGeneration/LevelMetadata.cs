using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using BaseGameLogic.Singleton;
using BaseGameLogic.Utilities;

public class LevelMetadata : SingletonMonoBehaviour<LevelMetadata>
{
    [Serializable] public class Level
    {
        [Serializable] public class Flor
        {
            [SerializeField] private List<Room> _rooms = new List<Room>();
            public List<Room> Rooms { get { return _rooms; } }

            public float Height { get { return _rooms[0].transform.position.y; } }
            [SerializeField] private float _groundLevel = .1f;
            public float GroundLevel { get { return _groundLevel; } }
            private float _width = 0;
            public float Width { get { return _width; } }

            public Flor(float groundLevel)
            {
                _groundLevel = groundLevel;
            }

            public void AddRoom(Room room)
            {
                _width += room.Size.y;
                _rooms.Add(room);
            }
        }

        [SerializeField] private List<Flor> _flors = new List<Flor>();
        public List<Flor> Flors { get { return _flors; } }
        public int Count { get { return _flors.Count; } }

        public void AddRoom(Room room, int index = -1)
        {
            if (_flors.Count > 0)
            {
                _flors[index < 0 ? _flors.Count - 1 : index].AddRoom(room);
            }
        }

        public void AddFlor(float groundLevel)
        {
            _flors.Add(new Flor(groundLevel));
        }

        public GameObject this [int x, int y]
        {
            get { return _flors[y].Rooms[x].gameObject; }
        }
    }

    [SerializeField] private Level _level = new Level();
    public Level LevelData { get { return _level; } }

    [SerializeField] private OrthogtaphicCameraBounds _levelBounds = new OrthogtaphicCameraBounds();
    public OrthogtaphicCameraBounds LevelBounds { get { return _levelBounds; } }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(_levelBounds.MinWidth, _levelBounds.MaxHeight, 0f), new Vector3(_levelBounds.MaxWidth, _levelBounds.MaxHeight, 0f));
        Gizmos.DrawLine(new Vector3(_levelBounds.MaxWidth, _levelBounds.MaxHeight, 0f), new Vector3(_levelBounds.MaxWidth, _levelBounds.MinHeight, 0f));
        Gizmos.DrawLine(new Vector3(_levelBounds.MinWidth, _levelBounds.MaxHeight, 0f), new Vector3(_levelBounds.MinWidth, _levelBounds.MinHeight, 0f));
        Gizmos.DrawLine(new Vector3(_levelBounds.MinWidth, _levelBounds.MinHeight, 0f), new Vector3(_levelBounds.MaxWidth, _levelBounds.MinHeight, 0f));

        Gizmos.color = Color.blue;
        for (int i = 0; i < LevelData.Flors.Count; i++)
        {
            var florTransform = LevelData[0, i].transform;
            Gizmos.DrawLine(
                florTransform.position + (florTransform.up * LevelData.Flors[i].GroundLevel), 
                florTransform.position + (florTransform.right * LevelData.Flors[i].Width) + (florTransform.up * LevelData.Flors[i].GroundLevel));
        }
    }
}
