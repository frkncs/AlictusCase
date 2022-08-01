using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSelectorSelectRingCharacterState : RingSelectorBaseState
{
    public RingSelectorSelectRingCharacterState(RingSelectorController controller) : base(controller)
    {
    }

    public override void Update()
    {
        if (Input.GetMouseButton(0))
        {
            controller.MoveRingAndSelectCharacter();   
        }
        else if (Input.GetMouseButtonUp(0))
        {
            controller.MouseUpped();
        }
    }
}
