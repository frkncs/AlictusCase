using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsManager : MonoBehaviour
{
    #region Variables

	// Public Variables

	// Private Variables
	[SerializeField] private RingManController ringManController;
	
	[Tooltip("Sort from bottom to top")]
	[SerializeField] private List<RingController> sortedRings;

	private RingSelectorController _ringSelectorController;

	#endregion Variables

	private void Start()
	{
		_ringSelectorController = GameObject.FindGameObjectWithTag("RingSelectorController")
			.GetComponent<RingSelectorController>();
	}

	public RingManController GetRingManController() => ringManController;
	
	public RingController GetTopRing()
	{
		return sortedRings.Count <= 0 ? null : sortedRings[sortedRings.Count - 1];
	}

	public void AddTopRing(RingController ringController)
	{
		sortedRings.Add(ringController);

		if (sortedRings.Count < _ringSelectorController.ringCount) return;
		
		var ringColor = sortedRings[0].GetRingColor();

		bool checkCanWin = true;
		
		foreach (var ring in sortedRings)
		{
			if (ring.GetRingColor() != ringColor)
			{
				checkCanWin = false;
				break;
			}
		}

		if (checkCanWin)
		{
			EffectManager.PlayCorrectMatchEffect?.Invoke();
			_ringSelectorController.IncreaseCorrectMatchedRingCount();
		}
	}
	public void RemoveTopRingFromList()
	{
		if (sortedRings.Count >= _ringSelectorController.ringCount)
		{
			var ringColor = sortedRings[0].GetRingColor();

			bool checkCanWin = true;
		
			foreach (var ring in sortedRings)
			{
				if (ring.GetRingColor() != ringColor)
				{
					checkCanWin = false;
					break;
				}
			}

			if (checkCanWin)
			{
				_ringSelectorController.DecreaseCorrectMatchedRingCount();
			}	
		}

		sortedRings.RemoveAt(sortedRings.Count - 1);
	}
}
