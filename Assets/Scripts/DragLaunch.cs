using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Lane lane;
	private Ball ball;
	private float timeStart, timeEnd;
	private Vector3 dragStart, dragEnd;
	
	void Start () {
		lane = FindObjectOfType<Lane>();
		
		ball = GetComponent<Ball>();
	}
	
	public void DragStart() {
		if (!ball.InPlay) {
			timeStart = Time.time;
			dragStart = Input.mousePosition;
			
			Debug.Log("DragStart()");
		}
	}
	
	public void MoveStart(float amount) {
		if (!ball.InPlay) {
			ball.transform.Translate(new Vector3(amount, 0, 0));
		}
	}
	
	public void DragEnd() {
		if (!ball.InPlay) {
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
	
}
