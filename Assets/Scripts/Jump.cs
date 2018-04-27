using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pose = Thalmic.Myo.Pose;

public class Jump : MonoBehaviour {
    public Rigidbody rb;
    public ThalmicMyo Myo;
    public bool isJumping = false;
    // Use this for initialization
    void Start() {
        StartCoroutine(MovementCheck());
}
        
    IEnumerator MovementCheck()
    {
        while (Application.isPlaying)
        {
            
            if(!isJumping && (Myo.accelerometer.y >= 1  || Input.GetKey(KeyCode.Return)))
            {
                rb.velocity = new Vector3(0, 3, 0);
                isJumping = true;
            }
            else if (isJumping && Myo.accelerometer.y < 1 && !Input.GetKey(KeyCode.Return))
            {
                isJumping = false;
            }
            yield return new WaitForSeconds(0.0001f);
        }
    }


	
	
}
