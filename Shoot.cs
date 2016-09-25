using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	public Text ammotext;
	public LayerMask goodLayer;
	public uint maxAmmo;
	public uint ammo;
	public float shootForce;

	RaycastHit hitInfo;
	Animator animator;

	void Start()
	{
		ammo = maxAmmo;
		animator = GetComponent<Animator> ();
		ammotext.text = "Ammo: " + ammo.ToString();
	}

	int animHash = Animator.StringToHash("Shoot");	

	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) {
			if (ammo > 0) {
				ammo--;
				animator.SetTrigger (animHash);
				GetComponent<AudioSource> ().Play ();
				GetComponentInChildren<ParticleSystem> ().Play ();

				GameObject camera = GameObject.Find ("Main Camera");
				if (Physics.Raycast (camera.transform.position, camera.transform.forward, out hitInfo, Mathf.Infinity)) {
					if (hitInfo.collider.gameObject.GetComponent<Shatter>()){
						Shatter targetClass = hitInfo.collider.gameObject.GetComponent<Shatter> ();
						targetClass.Explode (hitInfo.point);
					}
				}
			}
			ammotext.text = "Ammo: " + ammo.ToString ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			ammo = maxAmmo;
			ammotext.text = "Ammo: " + ammo.ToString ();
		}
	}
}