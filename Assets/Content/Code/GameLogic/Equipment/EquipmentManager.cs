using BaseGameLogic.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Equipment
{
    public class EquipmentManager : Singleton<EquipmentManager>
    {
        [SerializeField] private int _collectedPrice = 0;
        
        private Queue<ICollectable> collectables = new Queue<ICollectable>();

        public void EnqueueCollectible(ICollectable collectable)
        {
            collectables.Enqueue(collectable);
        }

        public void Stash()
        {
            while(collectables.Count > 0)
                _collectedPrice += collectables.Dequeue().Prize;
        }
    }
}
