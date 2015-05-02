using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	[SerializeField]
	private float standingThreshold = 11.3f;
	
	[SerializeField]
	private float moveSpeed = 2f;
	
	private Vector3 targetPosition;
	
	private bool isRaising = false;
	private bool isLowering = false;
	
	void Start () {
		//
	}
	
	void Update () {
		if (isRaising) {
			Raising();
		} else if (isLowering) {
			Lowering();
		}
	}
	
	void Raising() {
		if (transform.position != targetPosition) {
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);
		} else {
			isRaising = false;
		}
	}
	
	void Lowering() {
		if (transform.position != targetPosition) {
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);
		} else {
			isLowering = false;
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			rigidbody.isKinematic = false;
			rigidbody.useGravity = true;
		}
	}

	public void Raise(float distance) {
		if (IsStanding()) {
			targetPosition = new Vector3(transform.position.x, distance, transform.position.z);
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			isRaising = true;
		}
	}
	
	public void Lower(float distance) {
		if (IsStanding()) {
			targetPosition = new Vector3(transform.position.x, (transform.position.y-distance), transform.position.z);
			isLowering = true;
		}
	}
	
	public void Spawned(float distance) {
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		rigidbody.isKinematic = true;
		rigidbody.useGravity = false;
		Vector3 spawnPosition = new Vector3(transform.position.x, (transform.position.y+distance), transform.position.z);
		transform.position = spawnPosition;
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
