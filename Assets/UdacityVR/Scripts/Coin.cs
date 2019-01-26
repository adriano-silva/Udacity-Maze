using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// CoinPoof animation prefab
	public GameObject coinPoofPrefab;
	
	// Speed of rotation of the coin
	public float coinRotationSpeed;

	void Update () {
		transform.Rotate(0,coinRotationSpeed*Time.deltaTime,0);
	}


	public void OnCoinClicked () {
		// Prints to the console when the method is called
		Debug.Log ("'Coin.OnCoinClicked()' was called");

		// Displays a poof effect (handled by the 'KeyPoof' prefab)
		Instantiate(coinPoofPrefab, transform.position,transform.rotation,transform);
		// Removes the key from the scene
		Destroy(gameObject,0.5f);
	}
}
