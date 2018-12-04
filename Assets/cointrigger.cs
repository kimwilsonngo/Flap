using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cointrigger : MonoBehaviour {

	public int score = 0;
	// Use this for initialization

	void OnTriggerEnter(Collider player){
        AkSoundEngine.PostEvent("Coin", gameObject);
        ScoreScript.scoreValue +=1;
		Debug.Log("Score is " + score);
		Destroy(this.gameObject);
	}
}
