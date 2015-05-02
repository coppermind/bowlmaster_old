using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Ball ball;
	
	private float distance;
	
	void Start () {
		ball = FindObjectOfType<Ball>();
		distance = transform.position.z - ball.transform.position.z;
	}
	
	void Update () {
		if (ball.transform.position.z < 1700) {
			float newDistance = ball.transform.position.z + distance;
			transform.position = new Vector3(ball.transform.position.x, transform.position.y, newDistance);
		}
	}
}
