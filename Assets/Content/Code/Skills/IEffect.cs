using UnityEngine;

public interface IEffect
{
    void Activate(GameObject target);
    bool Update(float deltaTime);
    void Deactivate();
}