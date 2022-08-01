using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LaserDodgeCharacterMovement))]
public class LaserDodgeCharacterController : MonoBehaviour
{
    #region Variables

	// Public Variables
	[HideInInspector] public LaserDodgeCharacterMovement characterMovement { get; private set; }

	// Private Variables
	private CharacterBaseState _currentState;
	
	#endregion Variables
    
	private void Awake()
	{
		characterMovement = GetComponent<LaserDodgeCharacterMovement>();
		
		IdleState();
	}

	private void Start()
	{
		GameEvents.GameStartedEvent += RunState;
		GameEvents.WinEvent += IdleState;
		GameEvents.LoseEvent += IdleState;
	}

	private void Update()
    {
        _currentState.Update();
    }

	private void OnTriggerEnter(Collider other)
	{
		_currentState.OnTriggerEnter(other);
	}

	private void IdleState() => _currentState = new CharacterIdleState(this);
    private void RunState() => _currentState = new CharacterRunState(this);
}
