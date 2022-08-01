using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
	public enum GameIndex
	{
		Game01,
		Game02
	}
	
	[Header("Level")]
	[SerializeField] public GameObject levelObject;

	[SerializeField] public GameIndex gameIndex;
}
