using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathscore : MonoBehaviour {

    public Transform player;
    public GameObject xx;
    public Vector3 offset;
    public static  bool isdead = false;
    // Use this for initialization
    void Start () {
    }
    private void Update()
    {
        if(isdead == true)
        {
            this.transform.localPosition = player.localPosition + offset;
            StartCoroutine(MyMethod());
        }
    }
    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 2 seconds");
        yield return new WaitForSeconds(2);
        Debug.Log("After Waiting 2 Seconds");
        isdead = false;
        ScoreScript.scoreValue = 0;
        flightnew.start = false;
        player.GetComponent<Rigidbody>().isKinematic = false;

    }
    
    // Update is called once per frame
    public static void death()
    {
        isdead = true;
    }
}
