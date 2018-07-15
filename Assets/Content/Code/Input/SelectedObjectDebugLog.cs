using UnityEngine;

public class SelectedObjectDebugLog : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] private float _rayDuration = 1f;

    public void LogSelection(Vector3 poin, Vector3 normal, Rigidbody rigidbody, GameObject gameObject)
    {
        Debug.DrawRay(poin, normal, Color.red, _rayDuration);
        Debug.Log(poin);
        Debug.Log(normal);
        Debug.Log(gameObject.name);
    }
}
