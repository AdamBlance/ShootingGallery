using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	Vector2 mouseDelta;
	GameObject parent;

	public float verticalSensitivity;
	public float horizontalSensitivity;

	void Start(){
		parent = this.transform.parent.gameObject;
	}

	void Update (){
		Vector2 mouse = new Vector2 (Input.GetAxisRaw ("Mouse X") * horizontalSensitivity, Input.GetAxisRaw ("Mouse Y") * verticalSensitivity);
		mouse.y *= verticalSensitivity;
		mouse.x *= horizontalSensitivity;

		mouseDelta += mouse;
		mouseDelta.y = Mathf.Clamp (mouseDelta.y, -90f, 90f);
			
		transform.localRotation = Quaternion.AngleAxis (-mouseDelta.y, Vector3.right);
		parent.transform.localRotation = Quaternion.AngleAxis (mouseDelta.x, parent.transform.up);
	}
}

