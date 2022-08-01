using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    #region Variables

	// Public Variables

	// Private Variables
	[SerializeField] private GameObject winScreen;

	#endregion Variables
    
	private void Start()
	{
		GameEvents.WinEvent += ShowWinScreen;
	}

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }
}
