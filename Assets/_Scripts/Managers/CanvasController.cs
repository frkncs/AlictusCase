using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    #region Variables

	// Public Variables

	// Private Variables
	[SerializeField] private GameObject winScreen, loseScreen;

	#endregion Variables
    
	private void Start()
	{
		GameEvents.WinEvent += ShowWinScreen;
		GameEvents.LoseEvent += ShowLoseScreen;
	}

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }
    private void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
