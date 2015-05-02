using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 velocity;

	private AudioSource audioSource;
	private Rigidbody rigidBody;
	private bool ballInPlay = false;
	
	private Vector3 startPosition;

	void Start () {
		audioSource = GetComponent<AudioSource>();

		rigidBody = GetComponent<Rigidbody>();
		rigidBody.useGravity = false;
		
		startPosition = transform.position;
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
	
	public void Reset() {
		ballInPlay = false;
		
		transform.position = startPosition;
		transform.rotation = Quaternion.identity;
		
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}

}
