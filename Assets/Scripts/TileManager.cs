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
	private List<GameObject> activeTiles;
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
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * Spawnz;
		Spawnz += TileLength;
		activeTiles.Add (go);
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
		int randomLower = Random.Range (10, 30);
		int randomUpper = Random.Range (30,40);
		components [10].transform.localScale += new Vector3 (0, randomLower-1, 0);
		components [14].transform.localScale += new Vector3 (0, 50-randomLower-10, 0);
		components [18].transform.localPosition += new Vector3 (0, randomLower, 0);

	}

	private void RandomTileReSet(){
		GameObject test = Tiles [1];
		Component[] components = test.GetComponentsInChildren<Component> ();
		components [10].transform.localScale = new Vector3 (12, 1, 12);
		components [14].transform.localScale = new Vector3 (12, 1, 12);
		components [18].transform.localPosition = new Vector3 (-1, 1, -28);
	}

}
