using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawnManager : MonoBehaviour
{
    //A reference to the SpawnOccupied script
    public SpawnOccupied spawnOccupied;

    //A list of spawnpoints for the gun. These can me placed all over the level.
    public GameObject[] spawnPoints;
    //The gun itself. A second one of these will be needed for the armor
    public GameObject spawnableGun;
    //Same, but for the armor
    public GameObject spawnableArmor;

    //Max number of guns on a stage.
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
        //Maybe put something to the effect of spawnOccupied = FindObjectOfType<TetrisManager>(); here? Maybe with [] in there somewhere?

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
    }

    // Update is called once per frame
    void Update()
    {
        //Counts up from 0
        timeToSpawnGun += Time.deltaTime;

        //Same as above
        timeToSpawnArmor += Time.deltaTime;



        //The if statement that spawns the guns
        if (timeToSpawnGun >= maxGunSpawnTime && gunCount < 3) 
        {
            //Maybe try to add the spawn to an array and make NOT being on that array a part of spawning?
            //spawnOccupied.notHere.Contains()

            //Lets the code know a gun is on the stage. When a gun is picked up, this should be reduced.
            gunCount++;

            //Resets the time back down to 0
            timeToSpawnGun -= maxGunSpawnTime;

            //Picks one of the spawnpoints randomly from a list, then spawns the gun in that position.
            Instantiate(spawnableGun,spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }

        //Same as above but for armor
        if (timeToSpawnArmor >= maxArmorSpawnTime && armorCount < 2)
        {
            //Lets the code know a armor vest is on the stage. When a vest is picked up, this should be reduced.
            armorCount++;

            //Resets the time back down to 0
            timeToSpawnArmor -= maxArmorSpawnTime;

            //Picks one of the spawnpoints randomly from a list, then spawns the gun in that position.
            Instantiate(spawnableArmor, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }

    }
}
