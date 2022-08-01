using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RingSelectorBaseState
{
    protected RingSelectorController controller;
    
    public RingSelectorBaseState(RingSelectorController controller)
    {
        this.controller = controller;
    }

    public abstract void Update();
}
