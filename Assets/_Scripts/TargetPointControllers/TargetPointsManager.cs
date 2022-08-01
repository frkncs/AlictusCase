using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointsManager : MonoBehaviour
{
    #region Variables

	// Public Variables

	// Private Variables
	[SerializeField] private TargetPointController[] targetPointControllers;

	#endregion Variables
    
    public bool CheckAllPointPassed()
    {
	    bool isPassed = true;

	    foreach (var targetPointController in targetPointControllers)
	    {
		    if (!targetPointController.CheckCanPass())
		    {
			    isPassed = false;
			    break;
		    }
	    }

	    return isPassed;
    }
}
