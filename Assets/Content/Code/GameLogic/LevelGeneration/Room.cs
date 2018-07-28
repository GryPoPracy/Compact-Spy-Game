using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    public Bounds Bounds { get { return _spriteRenderer.bounds; } }
    public Vector3 Size { get { return _spriteRenderer.bounds.size; } }

    [SerializeField] private float _groundLevel = .1f;
    public float GroundLevel { get { return _groundLevel; } }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Vector3 start = this.transform.position + Vector3.up * _groundLevel;
    //    Vector3 end = start + Vector3.right * 2;
    //    Gizmos.DrawLine(start, end);
    //}
}
