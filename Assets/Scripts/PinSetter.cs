using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	
	public GameObject pinsFormation;
	public int lastStandingCount = -1;

	[SerializeField]
	private float settleTime = 3f;
	
	[SerializeField]
	private float distanceToRaise = 50f;

	private bool ballEnteredBox = false;
	private float lastChangeTime;

	private Ball ball;
	private Text totalText;
	
	void Start () {
		ball = FindObjectOfType<Ball>();
		
		GameObject pinTotalObject = GameObject.Find("Pin Total");
		totalText = pinTotalObject.GetComponent<Text>();
	}
	
	void Update () {
		totalText.text = CountStanding().ToString();
		
		if (ballEnteredBox) {
			CheckStandingPins();
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.GetComponent<Ball>()) {
			ballEnteredBox = true;
			totalText.color = Color.red;
		}
	}
	
	void OnTriggerExit(Collider collider) {
		if (collider.name == "Pin_Collider") {
			Pin parent = collider.gameObject.GetComponentInParent<Pin>();
			Destroy(parent.gameObject);
		}
	}
	
	void CheckStandingPins() {
		int currentStanding = CountStanding();
		
		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}
		
		if ((Time.time - lastChangeTime) > settleTime) {
			PinsHaveSettled();
		}
	}
	
	void PinsHaveSettled() {
		ball.Reset();
		lastStandingCount = -1; // Indicates pins have settled, and ball not in box
		ballEnteredBox = false;
		totalText.color = Color.green;
	}
	
	public void RaisePins() {
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
			pin.Raise(distanceToRaise);
		}
	}
	
	public void LowerPins() {
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
			pin.Lower(distanceToRaise);
		}
	}
	
	public void ResetPins() {
		PinsFormation formation = GameObject.FindObjectOfType<PinsFormation>();
		if (formation) { Destroy(formation.gameObject); }
		
		formation = Instantiate(pinsFormation, new Vector3(0, 0, 1829), Quaternion.identity) as PinsFormation;
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
			pin.Spawned(distanceToRaise);
		}
	}
	
	public int CountStanding() {
		int standing = 0;
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()) { standing++; }
		}
		return standing;
	}
}
