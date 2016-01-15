using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

	void OnTriggerExit(Collider collider) {
		if(collider.tag == "enemy")
			Destroy (collider.gameObject);
	}
}
