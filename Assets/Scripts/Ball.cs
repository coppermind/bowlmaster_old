using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 velocity;

	AudioSource audioSource;
	Rigidbody rigidBody;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody>();
		
		rigidBody.useGravity = false;
	}
	
	public void Launch(Vector3 velocity) {
		audioSource.Play();
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
	}

}
