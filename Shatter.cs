using UnityEngine;
using System.Collections;

public class Shatter : MonoBehaviour {

	public GameObject shattered;
	public float radius, power, upwards;

	public void Explode (Vector3 hitPoint)
	{
		Destroy (gameObject);
		GameObject shatteredClone = (GameObject)Instantiate (shattered, transform.position, shattered.transform.rotation);
		Collider[] plateBits = Physics.OverlapSphere (transform.position, radius);

		foreach (Collider plateBit in plateBits) {
			Rigidbody rb = plateBit.GetComponent<Rigidbody> ();
			if (rb != null) {
				Debug.Log (gameObject.GetComponent<Rigidbody> ().velocity);
				rb.velocity = gameObject.GetComponent<Rigidbody> ().velocity;
				rb.AddExplosionForce (power, transform.position, radius, upwards);
				Destroy (shatteredClone, 5f);
			}
		}
	}
}