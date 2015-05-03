using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Ball ball;
	
	private Vector3 distance;
	
	void Start () {
		ball = FindObjectOfType<Ball>();
		distance = transform.position - ball.transform.position;
	}
	
	void Update () {
		if (ball.transform.position.z < 1700) {
			transform.position = ball.transform.position + distance;
		}
	}
}
