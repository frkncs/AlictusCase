using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RingManController : MonoBehaviour
{
    #region Variables

	// Public Variables
	[SerializeField] public RingsManager ringsManager;

	// Private Variables
	private Animator _animator;

	private readonly int DanceAnim = Animator.StringToHash("Dance");

	private const float CrossFadeDuration = .15f;
	
	#endregion Variables
    
	private void Awake()
	{
		_animator = GetComponent<Animator>();

		_animator.speed = Random.Range(.85f, 1.25f);
	}

	private void Start()
	{
		GameEvents.WinEvent += PlayDanceAnim;
	}

	private void PlayDanceAnim()
	{
		_animator.CrossFade(DanceAnim, CrossFadeDuration);
	}
}
