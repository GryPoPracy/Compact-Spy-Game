using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressIndicator : MonoBehaviour
{
    public UpdateProgressCallback ProgressUpdateCallback = new UpdateProgressCallback();

    [SerializeField] private float _current = 0;
    public float Current
    {
        get { return _current; }
        set
        {
            _current = value;
            ProgressUpdateCallback.Invoke(NormalizedProgress);
        }
    }

    public float NormalizedProgress { get { return _current / _max; } }

    [SerializeField] private float _max = 1f;
    public float Max
    {
        get { return _max; }
        set { _max = value; }
    }

    public void ResetProgress()
    {
        _current = 0;
    }

    private void Awake()
    {
        Current = 0f;
    }

    [Serializable] public class UpdateProgressCallback : UnityEvent<float> {}
}
