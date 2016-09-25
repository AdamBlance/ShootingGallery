using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5;
	Rigidbody rigidbody;

	void Start(){
		rigidbody = GetComponent<Rigidbody> ();
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Update (){
		transform.Translate (new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")) * speed * Time.deltaTime);
		if (Input.GetButtonDown ("Cancel")) {
			Cursor.lockState = CursorLockMode.None;
		}
	}
}