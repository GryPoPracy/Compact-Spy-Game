using BaseGameLogic.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Equipment
{
    public class EquipmentManager : SingletonMonoBehaviour<EquipmentManager>
    {
        [SerializeField] private int _collectedPrice = 0;
        [SerializeField] private int _priceInStash = 0;

        public PriceUpdateCallback CollectedPricehUpdateCallback = new PriceUpdateCallback();
        public PriceUpdateCallback StashUpdateCallback = new PriceUpdateCallback();

        public void EnqueueCollectible(ICollectable collectable)
        {
            _collectedPrice += collectable.Prize;
            CollectedPricehUpdateCallback.Invoke(_collectedPrice.ToString());
        }

        public void ClearCollectedPrice()
        {
            _collectedPrice = 0;
            CollectedPricehUpdateCallback.Invoke(_collectedPrice.ToString());
        }

        public void Stash()
        {
            _priceInStash += _collectedPrice;
            _collectedPrice = 0;

            CollectedPricehUpdateCallback.Invoke(_collectedPrice.ToString());
            StashUpdateCallback.Invoke(_priceInStash.ToString());
        }
    }
    [Serializable] public class PriceUpdateCallback : UnityEvent<string> {} 
}
