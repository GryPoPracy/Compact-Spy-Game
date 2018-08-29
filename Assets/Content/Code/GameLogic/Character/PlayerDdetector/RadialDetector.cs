using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class RadialDetector : BaseDetctorLogic
{
    [SerializeField] private SphereCollider _sphereCollider = null;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _angle = 20;

    private GameObject _gameObject = null;

    public override float Detect(float detectionRate, LayerMask layerMask)
    {
        if (_gameObject != null)
        {
            Vector3 targetDirection = _gameObject.transform.position - transform.position;
            targetDirection.z = 0;
            float x = Vector3.Dot(transform.up, targetDirection);
            Debug.Log(x);
            Debug.DrawRay(this.transform.position, targetDirection);
            if (x < 0)
            {
                float angle = Vector3.Angle(targetDirection, -transform.up);
                if (angle <= _angle / 2)
                {
                    Debug.Log("Detected.");
                }
            }
        }


        return 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        _gameObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        
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
}
