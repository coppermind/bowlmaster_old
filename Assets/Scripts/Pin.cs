using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	[SerializeField]
	private float yEventHorizon = -20f;
	
	[SerializeField]
	private float standingThreshold = 11.3f;
	
	void Update () {
		if (yEventHorizon > transform.position.y) {
			Destroy(gameObject);
		}
	}
	
	public bool IsStanding() {
		Vector3 eulerRotation = transform.rotation.eulerAngles;
		
		float xTilt = Mathf.Abs(eulerRotation.x);
		float zTilt = Mathf.Abs(eulerRotation.y);

		float reverseThreshold = 360 - standingThreshold;
		if (xTilt > standingThreshold && xTilt < reverseThreshold) {
			return false;
		}
		if (zTilt > standingThreshold && zTilt < reverseThreshold) {
			return false;
		}
		return true;

	}
}
