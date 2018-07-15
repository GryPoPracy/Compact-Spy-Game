using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Equipment
{

    public class Collectable : MonoBehaviour, ICollectable
    {
        [SerializeField] private int _prize = 100;
        public int Prize { get { return _prize; } }

    }
}