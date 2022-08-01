using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    #region Variables

	// Public Variables
	public static Action PlayCorrectMatchEffect;

	// Private Variables
	[Header("Feedbacks")]
	[SerializeField] private MMFeedbacks winFeedbacks;
	[SerializeField] private MMFeedbacks correctEventFeedbacks;

	#endregion Variables
    
	private void Start()
	{
		GameEvents.WinEvent += PlayWinFeedback;
		PlayCorrectMatchEffect += PlayCorrectEventFeedback;
	}

	private void OnDestroy()
	{
		PlayCorrectMatchEffect = null;
	}

	private void PlayWinFeedback()
    {
	    winFeedbacks.PlayFeedbacks();
    }

    private void PlayCorrectEventFeedback()
    {
	    correctEventFeedbacks.PlayFeedbacks();
    }
}
