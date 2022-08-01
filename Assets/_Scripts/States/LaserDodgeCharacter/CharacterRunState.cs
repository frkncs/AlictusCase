using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRunState : CharacterBaseState
{
    public CharacterRunState(LaserDodgeCharacterController controller) : base(controller)
    {
    }

    public override void Update()
    {
        controller.characterMovement.Move();

        if (controller.characterMovement.CheckCanSlowDown())
        {
            controller.characterMovement.SetSlowSpeed();
        }
        else
        {
            controller.characterMovement.SetNormalSpeed();
        }
    }
}
