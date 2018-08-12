using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteRendererColorSkillEffector : BaseSkillEffector
{
    [SerializeField] private Color _color = Color.white;

    public override void Effect(GameObject target)
    {
        var spriteRenderer = target.GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null)
            spriteRenderer.color = _color;
    }
}
