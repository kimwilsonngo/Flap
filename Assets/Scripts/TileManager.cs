using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] Tiles;
	private Transform playerTransform;
    private int test = 0;
	private float Spawnz = 0.0f;
	private float TileLength = 48.0f;
	private float safeZone = 60.0f;
	private int amnTilesOnScree = 7;
	private int lastPrefabIndex = 0;
    private float speakerLoc = 0f;
    private int increment = 17;
    private int randomLower = 0;
    private int randomUpper = 0;
	private List<GameObject> activeTiles;
    private Vector3 getSpeakerLocation = new Vector3();
	// Use this for initialization
	void Start () {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for (int i = 0; i < amnTilesOnScree; i++) {
			SpawnTile ();
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (flightnew.start == false && test == 1)
        {
            DeleteAll();

            test = 0;

             Spawnz = 0.0f;
             TileLength = 48.0f;
             safeZone = 60.0f;
             amnTilesOnScree = 7;
             lastPrefabIndex = 0;
            activeTiles = new List<GameObject>();
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            for (int i = 0; i < amnTilesOnScree; i++)
            {
                SpawnTile();
            }

        }
        if(flightnew.start == true)
        {
            test = 1;
        }
		if (playerTransform.position.z  > (Spawnz - (amnTilesOnScree * TileLength))) {
			SpawnTile ();
			DeleteTile ();
		}
		
	}

	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject go;
		RandomTileSet ();
		go = Instantiate (Tiles [RandomPrefab()]) as GameObject;
        //AkAmbient.Instantiate(go).AddComponent();
        //go.AddComponent(typeof(AkAmbient));
        //go.AddComponent<AkAmbient>();
        //AkAmbient ak = go.AddComponent<AkAmbient>() as AkAmbient;

        //make tiles initially game objects to modify them after theyre created

        //transforms are a component attached to a game object. can't really do this.
        //Transform hi = transform;
        //hi.Translate(new Vector3(0, 10, 0));

        //AkSoundEngine.set
        //https://www.reddit.com/r/GameAudio/comments/26gqih/wwise_with_unity_development/
        GameObject speaker1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //GameObject speaker1 = new GameObject();

        speaker1.transform.position = go.transform.position;
        var a = speaker1.transform.position;
        speakerLoc += a.z;
        speaker1.transform.position = new Vector3(a.x, 0, speakerLoc);
        speaker1.transform.position += getSpeakerLocation;
        increment += 3;
        speakerLoc += TileLength - increment;
        

        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * Spawnz;

        Spawnz += TileLength;
		activeTiles.Add (go);

        //speaker1.transform.position = new Vector3(a.x, a.y + 17, Spawnz);



        AkSoundEngine.RegisterGameObj(speaker1);
        AkSoundEngine.SetObjectPosition(speaker1, speaker1.transform);
        AkSoundEngine.PostEvent("Pipe", speaker1);

        RandomTileReSet ();


	}

	private void DeleteTile(){
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);

	}
    public void DeleteAll()
    {

        foreach (GameObject goWp in activeTiles)
        {
            Destroy(goWp);
            
        }

        for (var i = 0; i < activeTiles.Count; i++)
        {
            activeTiles.RemoveAt(i);
        }

    }

	private int RandomPrefab(){
		if (Tiles.Length <= 1)
			return 0;
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex) {
			randomIndex = Random.Range (0, Tiles.Length);
		}
		lastPrefabIndex = randomIndex;
		return randomIndex;
	}

	private void RandomTileSet(){
		GameObject test = Tiles [1];
		Component[] components = test.GetComponentsInChildren<Component> ();
		randomLower = Random.Range (10, 30);
		randomUpper = Random.Range (30,40);
		components [10].transform.localScale += new Vector3 (0, randomLower-1, 0);
		components [14].transform.localScale += new Vector3 (0, 50-randomLower-10, 0);
		components [18].transform.localPosition += new Vector3 (0, randomLower, 0);
        getSpeakerLocation = components[18].transform.localPosition;


    }

	private void RandomTileReSet(){
		GameObject test = Tiles [1];
		Component[] components = test.GetComponentsInChildren<Component> ();
		components [10].transform.localScale = new Vector3 (12, 1, 12);
		components [14].transform.localScale = new Vector3 (12, 1, 12);
		components [18].transform.localPosition = new Vector3 (-1, 1, -28);
	}

}
