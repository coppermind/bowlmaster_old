using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	Text totalText;
	
	bool ballEnteredBox = false;

	void Update () {
		GameObject pinTotalObject = GameObject.Find("Pin Total");
		totalText = pinTotalObject.GetComponent<Text>();
		totalText.text = CountStanding().ToString();
	}
	
	void OnTriggerEnter(Collider collider) {
		Ball ball = collider.GetComponent<Ball>();
		if (ball) {
			ballEnteredBox = true;
			totalText.color = new Color(1f, 0.25f, 0.25f);
		}
	}
	
	void OnTriggerExit(Collider collider) {
		if (collider.name == "Pin_Collider") {
			Destroy(collider.gameObject);
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
