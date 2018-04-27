using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTest : MonoBehaviour
{
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "coin")
            return;
        else
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            Death();
        }
    }


    public void Death()
    {
        deathscore.death();
        Debug.Log("lol");
    }
}
