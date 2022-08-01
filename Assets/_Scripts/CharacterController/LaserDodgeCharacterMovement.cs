using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDodgeCharacterMovement : MonoBehaviour
{
    #region Variables

	// Public Variables

	// Private Variables
	[SerializeField] private LayerMask laserLayer;
	
	private float _moveSpeed = 8f;
	
	private const float NormalSpeed = 8f;
	private const float SlowSpeed = 4f;

	#endregion Variables

	public void Move()
	{
		transform.position += Vector3.forward * (Time.deltaTime * _moveSpeed);
	}

	public bool CheckCanSlowDown()
	{
		if (Physics.Raycast(transform.position, Vector3.forward, 6f, laserLayer))
		{
			return true;
		}

		return false;
	}

	public void SetSlowSpeed() => _moveSpeed = SlowSpeed;
	public void SetNormalSpeed() => _moveSpeed = NormalSpeed;
}
