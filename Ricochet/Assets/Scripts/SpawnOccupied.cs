using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnOccupied : MonoBehaviour
{
    public List<SpawnOccupied> notHere = new List<SpawnOccupied>();

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
        //Adds 
        if (isOccupied == true) 
        {
            notHere.Add(this);
        }
    }

    //if whatever this is attached to touches something tagged "items", then mark it as occupied 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnCollisionEnter2D");

        if (collision.gameObject.CompareTag("items"))
        {
            isOccupied = true;
        }
    }
}
