using UnityEngine;

public class Points : MonoBehaviour
{
	#region Properties
	public int CurrentPoints { get; set; }

	#endregion

	#region Unity Callbacks
	void Start()
	{
		CurrentPoints = 0;
	}

	#endregion

	#region Public Methods
	public void AddPoints(int pointsToAdd)
	{
		CurrentPoints += pointsToAdd;
	}
	#endregion
}
