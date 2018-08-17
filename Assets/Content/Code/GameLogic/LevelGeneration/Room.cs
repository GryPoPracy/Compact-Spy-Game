using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseGameLogic.LevelGeneration
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer = null;
        public Bounds Bounds { get { return _spriteRenderer.bounds; } }
        public Vector3 Size { get { return _spriteRenderer.bounds.size; } }

        [SerializeField] private float _groundLevel = .1f;
        public float GroundLevel { get { return _groundLevel; } }
    }
}