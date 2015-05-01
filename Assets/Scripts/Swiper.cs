using UnityEngine;
using System.Collections;

public class Swiper : MonoBehaviour {

	[SerializeField]
	private GameObject pinsFormation;
	
	private bool droppingPins = false;

	void Update () {
	
	}
	
	private void ResetPins() {
		GameObject formation = Instantiate(pinsFormation, new Vector3(0, 45f, 1829f), Quaternion.identity) as GameObject;
		foreach (Transform pinTransform in formation.transform) {
			Rigidbody pinRigidBody = pinTransform.gameObject.GetComponent<Rigidbody>();
			pinRigidBody.isKinematic = true;
		}
	}
	
	private void DropPins() {
		PinsFormation formation = FindObjectOfType<PinsFormation>();
		foreach (Transform pinTransform in formation.transform) {
			Rigidbody pinRigidBody = pinTransform.gameObject.GetComponent<Rigidbody>();
			pinRigidBody.isKinematic = false;
		}
	}
	
	private void RaisePins() {
		PinsFormation formation = FindObjectOfType<PinsFormation>();
		foreach (Transform pinTransform in formation.transform) {
			Rigidbody pinRigidBody = pinTransform.gameObject.GetComponent<Rigidbody>();
			pinRigidBody.isKinematic = true;
		}
	}
}
