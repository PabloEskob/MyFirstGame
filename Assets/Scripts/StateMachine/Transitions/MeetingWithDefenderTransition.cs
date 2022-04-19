using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetingWithDefenderTransition : Transition
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Shoot defender))
        {
            NeedTransit = true;
        }
    }
}
