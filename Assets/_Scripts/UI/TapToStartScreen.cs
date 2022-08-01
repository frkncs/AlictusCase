using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStartScreen : MonoBehaviour
{
    #region Variables

	// Public Variables

	// Private Variables

	#endregion Variables
    
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameEvents.GameStartedEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
