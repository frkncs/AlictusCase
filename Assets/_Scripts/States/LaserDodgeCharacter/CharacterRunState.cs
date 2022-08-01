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

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LaserHitCollider"))
        {
            if (!controller.characterMovement.CheckAllPointsPassed())
            {
                GameEvents.LoseEvent?.Invoke();
            }
        }
        else if (other.CompareTag("LaserPassCollider"))
        {
            LaserManager.IncreaseCurrentLaserIndexEvent?.Invoke();
            EffectManager.PlayCorrectMatchEffect?.Invoke();

            other.enabled = false;
        }
    }
}
