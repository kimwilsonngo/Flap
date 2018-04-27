using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {

        public Rigidbody rb;
        public ThalmicMyo Myo1;
        public ThalmicMyo Myo2;
        public bool isJumping = false;
        // Use this for initialization
        void Start()
        {
            StartCoroutine(MovementCheck());
        }

        IEnumerator MovementCheck()
        {
            while (Application.isPlaying)
            {

                if (!isJumping && (Myo1.accelerometer.y >= 1 || Input.GetKey(KeyCode.Return)))
                {
                    rb.velocity = new Vector3(0, 0, 3);
                    isJumping = true;
                }
                else if (isJumping && Myo1.accelerometer.y < 1 && !Input.GetKey(KeyCode.Return))
                {
                    isJumping = false;
                }
                else if (isJumping && (Myo2.accelerometer.y >= 1 || Input.GetKey(KeyCode.Return)))
                {
                    rb.velocity = new Vector3(0, 4, 0);
                    isJumping = true;
                }
                else if(isJumping && Myo2.accelerometer.y < 1 && !Input.GetKey(KeyCode.Return))
                {
                    isJumping = false;
                }
                else if(isJumping && ((Myo1.accelerometer.y >= 1 && Myo2.accelerometer.y >= 1) || Input.GetKey(KeyCode.Return)))
                {
                    rb.velocity = new Vector3(0, 4, 3);
                    isJumping = true;
                }
                else if(isJumping && ((Myo1.accelerometer.y < 1 && Myo2.accelerometer.y < 1) || !Input.GetKey(KeyCode.Return)))
                {
                    isJumping = false;
                }
                yield return new WaitForSeconds(0.0001f);
            }
        }




    }
