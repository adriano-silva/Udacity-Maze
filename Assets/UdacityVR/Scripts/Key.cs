using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Key : MonoBehaviour {
	// KeyPoof animation prefab
	public GameObject keyPoofPrefab;
	// Door object
	public Door door;
	// Speed of rotation of the key
	public float keyRotationSpeed;

	void Update () {
		transform.Rotate(0,0,keyRotationSpeed*Time.deltaTime);
	}


	public void OnKeyClicked () {
		// Prints to the console when the method is called
		Debug.Log ("'Key.OnKeyClicked()' was called");

		// Unlocks the door (handled by the Door class)
		door.Unlock();
		// Displays a poof effect (handled by the 'KeyPoof' prefab)
		Instantiate(keyPoofPrefab, transform.position,transform.rotation,transform);
		// Removes the key from the scene
		Destroy(gameObject,0.5f);
	}
}
