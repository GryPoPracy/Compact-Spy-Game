using BaseGameLogic.Singleton;
using BaseGameLogic.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : Singleton<LevelInfo>
{
    [SerializeField] private OrthogtaphicCameraBounds _levelBounds = new OrthogtaphicCameraBounds();
    public OrthogtaphicCameraBounds LevelBounds { get { return _levelBounds; } }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(_levelBounds.MinWidth, _levelBounds.MaxHeight, 0f), new Vector3(_levelBounds.MaxWidth, _levelBounds.MaxHeight, 0f));
        Gizmos.DrawLine(new Vector3(_levelBounds.MaxWidth, _levelBounds.MaxHeight, 0f), new Vector3(_levelBounds.MaxWidth, _levelBounds.MinHeight, 0f));
        Gizmos.DrawLine(new Vector3(_levelBounds.MinWidth, _levelBounds.MaxHeight, 0f), new Vector3(_levelBounds.MinWidth, _levelBounds.MinHeight, 0f));
        Gizmos.DrawLine(new Vector3(_levelBounds.MinWidth, _levelBounds.MinHeight, 0f), new Vector3(_levelBounds.MaxWidth, _levelBounds.MinHeight, 0f));
    }
}
