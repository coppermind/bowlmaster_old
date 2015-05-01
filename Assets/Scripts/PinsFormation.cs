using UnityEngine;
using System.Collections;

public class PinsFormation : MonoBehaviour {

	void Update () {
		if (0 >= transform.childCount) {
			Destroy(gameObject);
		}
	}
}
