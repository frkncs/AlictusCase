using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TargetPointController : MonoBehaviour
{
    #region Variables

	// Public Variables
	[SerializeField] public Transform connectedRigTransform;

	// Private Variables
	[SerializeField] private LayerMask laserLayer;

	private Renderer _renderer;
	private ParticleSystem _selectParticle;

	private Vector3 _defScale;

	private bool _canPass;
	
	#endregion Variables

	private void Awake()
	{
		_renderer = GetComponent<Renderer>();
		_selectParticle = GetComponentInChildren<ParticleSystem>();
		_defScale = transform.localScale;
	}

	private void Update()
	{
		if (Physics.Raycast(transform.position, Vector3.forward, float.MaxValue, laserLayer))
		{
			_canPass = false;
			SetColor(Color.red);
		}
		else
		{
			_canPass = true;
			SetColor(Color.green);
		}
	}

	public bool CheckCanPass() => _canPass;

	public void PlaySelectParticle()
	{
		_selectParticle.Play();
	}

	public void PlaySelectedAnimation()
	{
		transform.DOKill();
		transform.localScale = _defScale;
		
		transform.DOScale(_defScale * 1.45f, .15f)
			.SetEase(Ease.OutExpo);
	}

	public void PlayUnselectedAnimation()
	{
		transform.DOKill();
		
		transform.DOScale(_defScale, .15f)
			.SetEase(Ease.Linear);
	}
	
	private void SetColor(Color color)
	{
		if (_renderer.material.color == color) return;
		
		_renderer.material.color = color;
	}
}
