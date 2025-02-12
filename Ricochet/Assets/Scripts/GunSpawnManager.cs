using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawnManager : MonoBehaviour
{
    //Rather then the above that gets the script itself, this can be used to find all the game objects that are tagged as spawnpoints
    public GameObject[] daSpawns;

    //A list of spawnpoints for the gun. These can me placed all over the level.
    public GameObject[] spawnPoints;
    //The gun itself. A second one of these will be needed for the armor
    public GameObject spawnableGun;
    //Same, but for the armor
    public GameObject spawnableArmor;

    //Max number of guns on a stage. You may want to make a maxGunCount int rather then have it be hardcoded as well.
    public int gunCount;
    //Max number of armor vests on the stage
    public int armorCount;

    //Time until the gun is spawned. For the final version, this can either be used with or replaced with a check of if the players both have guns or not.
    public float timeToSpawnGun;
    //Works with the above. 
    public float maxGunSpawnTime;

    //Same as the above
    public float timeToSpawnArmor;
    public float maxArmorSpawnTime;



    // Start is called before the first frame update
    void Start()
    {
        //timeToSpawnGun is supposed to count up from 0 until it reaches maxGunSpawnTime, then that can be used to trigger the spawn. Can / should be replaced later when we 
        //have actual guns in the character's hands.
        timeToSpawnGun = 0.0f;
        maxGunSpawnTime = 5.0f;

        //Same as the above.
        timeToSpawnArmor = 0.0f;
        maxArmorSpawnTime = 12.0f;

        //This is the default number of guns. 
        gunCount = 0;
        //This is the default number of armor vests
        armorCount = 0;

        //This locates every gameobject that is tagged "Spawns"
        daSpawns = GameObject.FindGameObjectsWithTag("Spawns");
    }

    // Update is called once per frame
    void Update()
    {
        //Counts up from 0
        timeToSpawnGun += Time.deltaTime;

        //Same as above
        timeToSpawnArmor += Time.deltaTime;

        //This should be used so that every spawnpoint can be checked for if it's occupied or not?
        foreach (GameObject spawns in daSpawns) 
        {
            //The if statement that spawns the guns
            if (timeToSpawnGun >= maxGunSpawnTime && gunCount < 3 && spawns.GetComponent<SpawnOccupied>().isOccupied == false)
            {
                //Maybe try to add the spawn to an array and make NOT being on that array a part of spawning?
                //spawnOccupied.notHere.Contains()

                //Lets the code know a gun is on the stage. When a gun is picked up, this should be reduced.
                gunCount++;

                //Resets the time back down to 0
                timeToSpawnGun -= maxGunSpawnTime;

                //Picks one of the spawnpoints randomly from a list, then spawns the gun in that position.
                Instantiate(spawnableGun, spawns.transform.position, Quaternion.identity);
            }

            //Same as above but for armor
            if (timeToSpawnArmor >= maxArmorSpawnTime && armorCount < 2 && spawns.GetComponent<SpawnOccupied>().isOccupied == false)
            {

                //&& spawnOccupied.isOccupied == false
                //Lets the code know a armor vest is on the stage. When a vest is picked up, this should be reduced.
                armorCount++;

                //Resets the time back down to 0
                timeToSpawnArmor -= maxArmorSpawnTime;

                //Picks one of the spawnpoints randomly from a list, then spawns the gun in that position.
                Instantiate(spawnableArmor, spawns.transform.position, Quaternion.identity);
            }
        }
    }
}
