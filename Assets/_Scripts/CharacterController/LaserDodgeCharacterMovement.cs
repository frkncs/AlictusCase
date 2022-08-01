using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDodgeCharacterMovement : MonoBehaviour
{
    #region Variables

	// Public Variables

	// Private Variables
	private float _moveSpeed = 8f;

	#endregion Variables

	public void Move()
	{
		transform.position += Vector3.forward * (Time.deltaTime * _moveSpeed);
	}

	public void SetSlowSpeed() => _moveSpeed /= 2;
	public void SetNormalSpeed() => _moveSpeed *= 2;
}
