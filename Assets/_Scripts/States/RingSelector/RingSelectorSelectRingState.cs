using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSelectorSelectRingState : RingSelectorBaseState
{
    public RingSelectorSelectRingState(RingSelectorController controller) : base(controller)
    {
    }

    public override void Update()
    {
        if (Input.GetMouseButton(0))
        {
            controller.SelectRing();   
        }
    }
}
