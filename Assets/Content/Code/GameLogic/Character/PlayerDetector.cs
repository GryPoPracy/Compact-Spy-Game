using BaseGameLogic.States;
using Character.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask = new LayerMask();
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        [SerializeField] private float _detectionDistance = 2f;

        private void Update()
        {
            var end = this.transform.position + (spriteRenderer.flipX ? -transform.right : transform.right) * _detectionDistance;
            RaycastHit2D hit2D = Physics2D.Linecast(this.transform.position, end, layerMask);
            Debug.DrawLine(this.transform.position, end);
            if (hit2D)
            {
                var state = GetComponent<StateHandler>().CurrentStateInterfaceHandler.CurrentState;
                if (state is HideState2D)
                    Debug.LogFormat("I cant see {0}", hit2D.collider.name);
                else
                    Debug.LogFormat("I see {0}", hit2D.collider.name);
            }
        }
    }
} 
