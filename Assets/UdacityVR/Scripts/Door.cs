using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// GameObject of the 'Left_Door' game object
	public GameObject leftDoor;
	// GameObject of the 'Right_Door' game object
	public GameObject rightDoor;
	
	// AudioSource get a reference to the audio source in Start()
	public AudioSource audioSource;

	// Boolean to track if the door has been unlocked
	private bool locked = true ;
	// Boolean to track if the door is opening
	private bool opening = false;
	
	// Quaternion to hold the start rotation of the 'Left_Door' game object
	private Quaternion leftDoorStartRotation;
	// Quaternion to hold the end rotation of the 'Left_Door' game object
	private Quaternion leftDoorEndRotation;
	// Quaternion to hold the start rotation of the 'Right_Door' game object
	private Quaternion rightDoorStartRotation;
	// Quaternion to hold the end rotation of the 'Right_Door' game object
	private Quaternion rightDoorEndRotation;

	// float to track the Quaternion.Slerp() interpolation 
	private float timer = 0f;
	// Float to set the Quaternion.Slerp() interpolation speed
	private float rotationTime = 5f;

	void Start () {
		// Getting reference of AudioSource component
		audioSource = GetComponent<AudioSource>();

		// Setting of start and end rotation values used when animating the door opening
		leftDoorStartRotation = leftDoor.transform.rotation;
		leftDoorEndRotation = leftDoorStartRotation * Quaternion.Euler(0f,0f,-90f);
		rightDoorStartRotation = rightDoor.transform.rotation;
		rightDoorEndRotation = rightDoorStartRotation * Quaternion.Euler(0f,0f,90f);
	}


	void Update () {
		// If door is opening, animate 'Left_Door' and 'Right_Door' game objects
		if (opening)
		{
			// Interpolating from 'leftDoorStartRotation' to 'leftDoorEndRotation' by the interpolation time 'rotationTime'
			leftDoor.transform.rotation = Quaternion.Slerp(leftDoorStartRotation, leftDoorEndRotation, timer / rotationTime);
			rightDoor.transform.rotation = Quaternion.Slerp(rightDoorStartRotation, rightDoorEndRotation, timer / rotationTime);
			timer += Time.deltaTime;
		}
	}


	public void OnDoorClicked () {
		// Called when the 'Left_Door' or 'Right_Door' game object is clicked
		// - Starts opening the door if it has been unlocked
		// - Plays an audio clip when the door starts opening

		// Prints to the console when the method is called
		Debug.Log ("'Door.OnDoorClicked()' was called");

		if (!locked)
		{
			opening = true;
			audioSource.Play();
		}

		// OPTIONAL-CHALLENGE: Prevent the door from being interacted with after it has started opening
		// TIP: You could disable the Event Trigger component, or for an extra challenge, try disabling all the Collider components on all children

		// OPTIONAL-CHALLENGE: Play a different sound if the door is locked
		// TIP: You could get a reference to the 'Door_Locked' audio and play it without assigning it to the AudioSource component
	}


	public void Unlock () {
		// Called from Key.OnKeyClicked(), i.e. the Key.cs script, when the 'Key' game object is clicked
		// - Unlocks the door

		// Prints to the console when the method is called
		Debug.Log ("'Door.Unlock()' was called");

		locked = false;
	}
}
