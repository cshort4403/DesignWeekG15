using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class ItemSpawnBehavior : MonoBehaviour
{

    [SerializeField] private bool SpawnOnStart;

    [SerializeField] private GameObject ItemToSpawn; //What item to spawn
    
    [SerializeField] float SpawnCooldown = 10f; //How long until it can spawn again

    float TimeSinceLastSpawn = 0f;
    bool IsOccupied = false;

    GameObject OccupyingObject;

    // Start is called before the first frame update
    void Start()
    {
        if (SpawnOnStart)TimeSinceLastSpawn = SpawnCooldown;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeSinceLastSpawn >= SpawnCooldown) 
        {
            SpawnItem();
           
        }
        else if(!IsOccupied) //Only enter cooldown if it is not already occupied
        {
            TimeSinceLastSpawn += Time.deltaTime;

            if(GetComponentInChildren<Light2D>().enabled) 
            {
				GetComponentInChildren<Light2D>().enabled = false;
			}
        }
        IsOccupied = OccupyingObject != null;
    }

	private void SpawnItem()
    {
        if (IsOccupied) { return; }

        OccupyingObject= Instantiate(ItemToSpawn, transform.position, Quaternion.identity);
        TimeSinceLastSpawn = 0f;
		GetComponentInChildren<Light2D>().enabled = true;
	}

    public void ResetItem()
    {
        Destroy(OccupyingObject);
		if (SpawnOnStart) TimeSinceLastSpawn = SpawnCooldown;
	}

}
