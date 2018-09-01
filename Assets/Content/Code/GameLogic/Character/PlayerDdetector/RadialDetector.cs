using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class RadialDetector : BaseDetctorLogic
{
    [SerializeField] private SphereCollider _sphereCollider = null;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _angle = 20;

    [SerializeField] private GameObject _gameObject = null;

    [SerializeField, Range(0f, 1f)] private float _detection = 0;

    public override float Detect(float detectionRate, LayerMask layerMask)
    {
        if (_gameObject != null)
        {
            Vector3 targetDirection = _gameObject.transform.position - transform.position;
            targetDirection.z = 0;
            if (Vector3.Dot(transform.up, targetDirection) < 0)
            {
                if (Vector3.Angle(targetDirection, -transform.up) <= _angle / 2)
                {
                    Debug.DrawRay(this.transform.position, targetDirection, Color.red);
                    _detection += Time.deltaTime * detectionRate;
                }
                else
                {
                    Debug.DrawRay(this.transform.position, targetDirection, Color.green);
                    _detection -= Time.deltaTime * detectionRate;
                }
            }
        }
        else
            _detection = 0;

        return (_detection = Mathf.Clamp01(_detection));
    }

    public override void Clear()
    {
        _detection = 0;
        _gameObject = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("Object {0} enter the detector collier.", other.gameObject.name);
        _gameObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if(_gameObject == other.gameObject)
        {
            Debug.LogFormat("Object {0} exit the detector collier.", other.gameObject.name);
            _gameObject = null;
        }
    }

    private void OnValidate()
    {
        _sphereCollider.isTrigger = true;
        _sphereCollider.radius = _radius;
    }

    private void Reset()
    {
        _sphereCollider = gameObject.GetComponent<SphereCollider>();
        _sphereCollider.isTrigger = true;
        _sphereCollider.radius = _radius;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        float angle = _angle / 2;
        Gizmos.DrawLine(this.transform.position, GetWorldPointOnCircle(angle, _radius, Vector3.forward, -Vector3.up));
        Gizmos.DrawLine(this.transform.position, GetWorldPointOnCircle(-angle, _radius, Vector3.forward, -Vector3.up));
        UnityEditor.Handles.color = Color.blue;
        UnityEditor.Handles.DrawWireArc(this.transform.position, transform.forward, -transform.up, angle, _radius);
        UnityEditor.Handles.DrawWireArc(this.transform.position, transform.forward, -transform.up, -angle, _radius);
    }

    public Vector3 GetWorldPointOnCircle(float angle, float radius, Vector3 rotationDirection, Vector3 direction)
    {
        Quaternion rotation = Quaternion.AngleAxis(angle, rotationDirection);
        Vector3 localPosition = rotation * (Vector3.zero + direction * radius);
        return transform.TransformPoint(localPosition);
    }
#endif
}
