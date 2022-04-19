using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedFinishLine : Transition
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out TheEnd target))
        {
            NeedTransit = true;
        }
    }
}
