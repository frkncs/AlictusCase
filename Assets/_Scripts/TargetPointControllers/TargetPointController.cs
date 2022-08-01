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
			SetColor(Color.red);
		}
		else
		{
			SetColor(Color.green);
		}
	}

	public void PlaySelectParticle()
	{
		_selectParticle.Play();
	}

	public void PlaySelectedAnimation()
	{
		transform.PlayScaleUpDownAnim(_defScale, 1.6f, .15f, Ease.OutExpo, Ease.Linear);
	}
	
	private void SetColor(Color color)
	{
		if (_renderer.material.color == color) return;
		
		_renderer.material.color = color;
	}
}
