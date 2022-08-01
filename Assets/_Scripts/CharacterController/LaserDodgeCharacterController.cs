using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(LaserDodgeCharacterMovement))]
public class LaserDodgeCharacterController : MonoBehaviour
{
    #region Variables

	// Public Variables
	[HideInInspector] public LaserDodgeCharacterMovement characterMovement { get; private set; }

	// Private Variables
	private TargetPointController[] _targetPointControllers;
	private Animator _animator;
	private RigBuilder _rigBuilder;
	private CharacterBaseState _currentState;

	private readonly int _danceAnim = Animator.StringToHash("Dance");
	private const float CrossFadeDuration = .15f;

	#endregion Variables
    
	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_rigBuilder = GetComponent<RigBuilder>();
		_targetPointControllers = GetComponentsInChildren<TargetPointController>();
		characterMovement = GetComponent<LaserDodgeCharacterMovement>();
		
		IdleState();
	}

	private void Start()
	{
		GameEvents.GameStartedEvent += RunState;
		GameEvents.WinEvent += WinState;
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

    private void WinState()
    {
	    _rigBuilder.enabled = false;

	    foreach (var targetPointController in _targetPointControllers)
	    {
		    targetPointController.gameObject.SetActive(false);
	    }

	    transform.DORotate(new Vector3(0, 180, 0), .8f, RotateMode.WorldAxisAdd)
		    .SetEase(Ease.OutSine);

	    PlayDanceAnim();
	    _currentState = new CharacterIdleState(this);
    }

    private void PlayDanceAnim()
    {
	    _animator.CrossFade(_danceAnim, CrossFadeDuration);
    }
}
