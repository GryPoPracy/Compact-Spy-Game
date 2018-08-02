using BaseGameLogic.Inputs.Screen;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer = null;
    [SerializeField] private float _turnOffDistance = .1f;
    private Coroutine _turnOffCorutine = null;

    private void Awake()
    {
        _renderer.enabled = false;    
    }

    public void Move(ClickInfo2D clickInfo2D)
    {
        var playerPosition = PlayerCharacter.Instance.transform.position;
        transform.position = new Vector3(clickInfo2D.WorldPosition.x, playerPosition.y, 0);
        _renderer.enabled = true;

        if (_turnOffCorutine != null)
            StopCoroutine(_turnOffCorutine);
        _turnOffCorutine = StartCoroutine(TurnOff());
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitUntil(() => { return Vector3.Distance(PlayerCharacter.Instance.transform.position, transform.position) <= _turnOffDistance; });
        _renderer.enabled = false;
    }
}
