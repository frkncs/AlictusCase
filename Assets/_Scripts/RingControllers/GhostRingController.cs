using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRingController : MonoBehaviour
{
    #region Variables

	// Public Variables

	// Private Variables
	[SerializeField] private GameObject pink, green, blue, yellow;

	#endregion Variables

	private void Awake()
	{
		HideGhostRing();
	}

	public void SetPosition(Vector3 pos, RingController.RingColor ringColor)
	{
		HideGhostRing();
		
		switch (ringColor)
		{
			case RingController.RingColor.Pink:
				pink.SetActive(true);
				break;
			case RingController.RingColor.Green:
				green.SetActive(true);
				break;
			case RingController.RingColor.Blue:
				blue.SetActive(true);
				break;
			case RingController.RingColor.Yellow:
				yellow.SetActive(true);
				break;
		}
		
		transform.position = pos;
	}

	public void HideGhostRing()
	{
		pink.SetActive(false);
		green.SetActive(false);
		blue.SetActive(false);
		yellow.SetActive(false);
	}
}
