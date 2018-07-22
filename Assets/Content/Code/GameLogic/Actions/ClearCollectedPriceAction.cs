using ActionsSystem;
using Equipment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCollectedPriceAction : BaseAction
{
    public override void Perform(params object[] list)
    {
        EquipmentManager.Instance.ClearCollectedPrice();
    }
}
