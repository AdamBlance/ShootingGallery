using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject target;

	void Update() {	
		if (Input.GetButtonDown ("Fire2")) 
		{
			GameObject targetInstance = (GameObject)Instantiate (target, transform.position, transform.rotation);
			targetInstance.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 500, 0));
			//targetInstance.GetComponent<Rigidbody> ().AddTorque (new Vector3 (100, 0, 0));
			Destroy (targetInstance, 5.0f);
		}

	}
}
