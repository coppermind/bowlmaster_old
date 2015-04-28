using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private float timeStart, timeEnd;
	private Vector3 dragStart, dragEnd;

	void Start () {
		ball = GetComponent<Ball>();
	}
	
	public void DragStart() {
		timeStart = Time.time;
		dragStart = Input.mousePosition;
	}
	
	public void DragEnd() {
		timeEnd = Time.time;
		dragEnd = Input.mousePosition;

		float dragDuration = timeEnd - timeStart;
		float launchSpeedX = (dragEnd.x - dragStart.x) * 0.25f / dragDuration;
		float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
		
		Debug.Log(launchSpeedX + ", " + launchSpeedZ + ", " + dragDuration);
		
		Vector3 velocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
		ball.Launch(velocity);
	}
	
}
