using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignPost : MonoBehaviour {

	public void ResetScene () {
		// Called when the 'SignPost' game object is clicked
		// - Reloads the scene

		// Prints to the console when the method is called
		Debug.Log ("'SignPost.ResetScene()' was called");
		// Use 'leftDoor' to get the start rotation of the 'Left_Door' game object and assign it to 'leftDoorStartRotation'
		
		// Resetting the scene by getting a reference to the scene and reloading it
		var scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}
