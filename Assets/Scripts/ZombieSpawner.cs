using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {

    public GameObject zombieObject;
    public float zombieSpawnTime;
    private Vector3 zombieSpawnPosition;
    //public Terrain terrain;
     
	void Start ()
    {
        InvokeRepeating("Spawn", zombieSpawnTime, zombieSpawnTime);
	
	}
	
	void Spawn()
    {
        float xPosition = Random.Range(PlayerController.player.transform.position.x + 15, PlayerController.player.transform.position.x + 50);
        zombieSpawnPosition = new Vector3 (xPosition, Terrain.activeTerrain.SampleHeight(new Vector3(xPosition, 0.0f, 0.0f)) - 35.0f,0.0f);
        Debug.Log(Terrain.activeTerrain.SampleHeight(new Vector3(xPosition, 0.0f, 0.0f))-35.0f + " - y position of spawned zombul)");
        Instantiate(zombieObject, zombieSpawnPosition, Quaternion.identity);
    }
}
