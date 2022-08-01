using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState
{
    protected LaserDodgeCharacterController controller;

    public CharacterBaseState(LaserDodgeCharacterController controller)
    {
        this.controller = controller;
    }

    public abstract void Update();
}
