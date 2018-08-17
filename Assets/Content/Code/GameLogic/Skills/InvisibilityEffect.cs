using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Skills
{
    public class InvisibilityEffect : IEffect
    {
        private Color color = Color.white;
        private float duration;
        private Collider2D collider2D = null;
        private SpriteRenderer spriteRenderer;

        public InvisibilityEffect(Color color, float duration)
        {
            this.color = color;
            this.duration = duration;
        }
    
        public void Activate(GameObject target)
        {
            collider2D = target.GetComponentInChildren<Collider2D>();
            collider2D.enabled = false;
            spriteRenderer = target.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.color = color;
        }

        public void Deactivate()
        {
            spriteRenderer.color = Color.white;
            collider2D.enabled = true;
        }

        public bool Update(float deltaTime)
        {
            return (duration -= deltaTime) <= 0;
        }
    }
}
