using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnOccupied : MonoBehaviour
{
    //A list of spawnpoints that are currently full.
    //public List<SpawnOccupied> notHere = new List<SpawnOccupied>();

    //The radius that the OverlapCircle should check for objects in. Just set it to the radius of the spawnpoint, like 1 or something, so it checks if anything is directly in it
    //public float checkRadius;

    //This is a declaration of what layer the OverlapCircle should look for. I think this works?
    //public LayerMask Items;

    //Without this it can't figure out 2d physics.
    private Rigidbody2D rb2d;

    //The variable that lets the back end code know if an item is currently occupying the position of the spawnpoint
    public bool isOccupied;
    // Start is called before the first frame update
    void Start()
    {
        isOccupied = false;

        //Needed for the spawn-hit registration so it knows the spawnpoint already has an item there
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Adds anything that is occupied to a list called notHere.
        //if (isOccupied == true) 
        //{
            //notHere.Add(this);
        //}

        //This basically raycasts in all directions from the spawnpoints transform.position for a distance of checkRadius and then checks for any objects under the layer "Items"
        //if (Physics2D.OverlapCircle(transform.position, checkRadius, Items))
        //{
            //Debug.Log("OverlapCircle firing");

            //isOccupied = true;
        //}
    }

    //if whatever this is attached to touches something tagged "items", then mark it as occupied 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnCollisionEnter2D");

        if (collision.gameObject.CompareTag("Items"))
        {
            isOccupied = true;
        }
    }
}
