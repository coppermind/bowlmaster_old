using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 velocity;

	AudioSource audioSource;
	Rigidbody rigidBody;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.velocity = velocity;
	}

}
