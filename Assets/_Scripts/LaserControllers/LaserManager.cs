using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    #region Variables

	// Public Variables
	public static Action IncreaseCurrentLaserIndexEvent;

	// Private Variables
	[SerializeField] private LaserController[] laserControllers;

	private int _currentLaserIndex;
	
	#endregion Variables

	private void Awake()
	{
		laserControllers[0].SetLayerToLaserLayer();
	}

	private void Start()
	{
		IncreaseCurrentLaserIndexEvent += IncreaseCurrentLaserIndex;
	}

	private void OnDestroy()
	{
		IncreaseCurrentLaserIndexEvent = null;
	}

	private void IncreaseCurrentLaserIndex()
	{
		if (_currentLaserIndex + 1 >= laserControllers.Length)
		{
			StartCoroutine(CallWinEventWithDelay(.6f));
			return;
		}
		
		_currentLaserIndex++;

		laserControllers[_currentLaserIndex].SetLayerToLaserLayer();
	}

	private IEnumerator CallWinEventWithDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		GameEvents.WinEvent?.Invoke();
	}
}
