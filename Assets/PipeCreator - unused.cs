using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCreator : MonoBehaviour {
    public GameObject[] pipes;
    public Vector3 pipeVal;
    public float pipeWait;
    public float pipeMWait;
    public float pipeLWait;
    public int startWait;
    public bool stop;
    int pipeRan;
    private List<GameObject> activePipes;
    // Use this for initialization
    void Start () {
        activePipes = new List<GameObject>();
        StartCoroutine(waitPiper());
        
    }
	
	// Update is called once per frame
	void Update () {
        pipeWait = Random.Range(pipeLWait, pipeMWait);
       // deletePipe();
    }
    IEnumerator waitPiper()
    {
        yield return new WaitForSeconds(startWait);
        int x = 1;
        int y;
        while (!stop)
        {
            Debug.Log("what da fack");
            x += 6;
            y = Random.Range(0, 6);
            pipeRan = Random.Range(0, 2);
            Vector3 pipePos = new Vector3(1, y, x);
            Instantiate(pipes[pipeRan], pipePos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            AkSoundEngine.PostEvent("Pipe", gameObject);
            yield return new WaitForSeconds(pipeWait);
        }

    }
    private void DeletePipe()
    {
        Destroy(activePipes[0]);
        activePipes.RemoveAt(0);
        RandomPipe();
    }
    private void RandomPipe()
    {
        GameObject test = pipes[1];
        Component[] components = test.GetComponentsInChildren<Component>();
        foreach (Component component in components)
            Debug.Log(component);
    }
}
