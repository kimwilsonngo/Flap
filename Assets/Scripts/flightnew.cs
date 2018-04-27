using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class flightnew : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 defaultt;
    public ThalmicMyo Myo1;
    public ThalmicMyo Myo2;
    public bool isJumping = false;
    public static bool start;
    public float forwarfVelocity = 25.0f;
    public float upwardVelocity = 10.0f;
    private bool isDead;
    // Use this for initialization
    void Start()
    {
        isDead = false;
        start = false;
        StartCoroutine(MovementCheck());

    }
    private void Update()
    {
        if (start == false)
        {
            isDead = false;
            rb.transform.position = defaultt;
        }
    }
    IEnumerator MovementCheck()
    {
        while (Application.isPlaying)
        {
            if (start == false)
            {
                rb.velocity = new Vector3(0, 0, 0);
                if (Myo1.accelerometer.y >= 1 || Myo2.accelerometer.y >= 1)
                    start = true;
                else
                    PrefabUtility.ResetToPrefabState(Selection.activeGameObject);
            }

            if (start == true)
            {
                AudioSource audio = GetComponent<AudioSource>();

                if (Myo1.accelerometer.y >= 1 && Myo2.accelerometer.y < 1)
                {
                    rb.velocity = new Vector3(0, upwardVelocity, forwarfVelocity);
                    audio.Play();
                    audio.Play(110000);
                }
                else if (Myo1.accelerometer.y < 1 && Myo2.accelerometer.y >= 1)
                {
                    rb.velocity = new Vector3(0, upwardVelocity, forwarfVelocity);
                    audio.Play();
                    audio.Play(110000);
                }
                else if (Myo1.accelerometer.y >= 1 && Myo2.accelerometer.y >= 1)
                {
                    rb.velocity = new Vector3(0, 2 * upwardVelocity, forwarfVelocity);
                    audio.Play();
                    audio.Play(110000);
                }
                else
                {

                    Vector3 v = rb.velocity;
                    v.x = 20.0f;
                    rb.velocity = v;
                    rb.AddForce(0, -5, 0);
                }
            }
            yield return new WaitForSeconds(0.0001f);

            //if (!isJumping && (Myo1.accelerometer.y >= 1 || Input.GetKey(KeyCode.Return)))
            //{
            //    rb.velocity = new Vector3(0, 0, 3);
            //    isJumping = true;
            //}
            //else if (isJumping && Myo1.accelerometer.y < 1 && !Input.GetKey(KeyCode.Return))
            //{
            //    isJumping = false;
            //}
            //else if (isJumping && (Myo2.accelerometer.y >= 1 || Input.GetKey(KeyCode.Return)))
            //{
            //    rb.velocity = new Vector3(0, 4, 0);
            //    isJumping = true;
            //}
            //else if (isJumping && Myo2.accelerometer.y < 1 && !Input.GetKey(KeyCode.Return))
            //{
            //    isJumping = false;
            //}
            //else if (isJumping && ((Myo1.accelerometer.y >= 1 && Myo2.accelerometer.y >= 1) || Input.GetKey(KeyCode.Return)))
            //{
            //    rb.velocity = new Vector3(0, 4, 3);
            //    isJumping = true;
            //}
            //else if (isJumping && ((Myo1.accelerometer.y < 1 && Myo2.accelerometer.y < 1) || !Input.GetKey(KeyCode.Return)))
            //{
            //    isJumping = false;
            //}
            //yield return new WaitForSeconds(0.0001f);
        }
    }






}
