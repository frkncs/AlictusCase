using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    #region Variables

	// Public Variables

	// Private Variables
	[SerializeField] private GameObject[] lasers;

	#endregion Variables

	public void SetLayerToLaserLayer()
	{
		foreach (var laser in lasers)
		{
			laser.layer = 8;
		}
	}
}
