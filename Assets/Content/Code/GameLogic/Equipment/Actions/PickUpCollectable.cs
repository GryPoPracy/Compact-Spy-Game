using UnityEngine;
using ActionsSystem;

namespace Equipment
{
    public class PickUpCollectable : BaseAction
    {
        [SerializeField] private Collectable collectable = null;

        public override void Perform(params object[] list)
        {
            EquipmentManager.Instance.EnqueueCollectible(collectable);
        }
    }
}