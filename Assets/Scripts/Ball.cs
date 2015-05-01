using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 velocity;

	private AudioSource audioSource;
	private Rigidbody rigidBody;
	private bool ballInPlay = false;
	

	void Start () {
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody>();
		
		rigidBody.useGravity = false;
	}
	
	public bool InPlay {
		get { return ballInPlay; }
		set { ballInPlay = value; }
	}
		
	public void Launch(Vector3 velocity) {
		ballInPlay = true;
		audioSource.Play();
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
	}

}
