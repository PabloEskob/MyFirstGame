using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDefender : Transition
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if ( other.TryGetComponent(out Shoot defender))
        {
            NeedTransit = true;
        }
    }
}
