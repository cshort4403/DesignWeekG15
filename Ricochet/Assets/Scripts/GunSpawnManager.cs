using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawnManager : MonoBehaviour
{

    //A list of spawnpoints for the gun. These can me placed all over the level.
    public GameObject[] spawnPoints;
    //The gun itself. A second one of these will be needed for the armor
    public GameObject spawnableGun;
    //Same, but for the armor
    public GameObject spawnableArmor;

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
    }

    // Update is called once per frame
    void Update()
    {
        //Counts up from 0
        timeToSpawnGun += Time.deltaTime;

        //Same as above
        timeToSpawnArmor += Time.deltaTime;

        //The if statement that spawns the guns
        if (timeToSpawnGun >= maxGunSpawnTime) 
        {
            //Resets the time back down to 0
            timeToSpawnGun -= maxGunSpawnTime;

            //Picks one of the spawnpoints randomly from a list, then spawns the gun in that position.
            Instantiate(spawnableGun,spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }

        //Same as above but for armor
        if (timeToSpawnArmor >= maxArmorSpawnTime)
        {
            //Resets the time back down to 0
            timeToSpawnArmor -= maxArmorSpawnTime;

            //Picks one of the spawnpoints randomly from a list, then spawns the gun in that position.
            Instantiate(spawnableArmor, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }

    }
}
