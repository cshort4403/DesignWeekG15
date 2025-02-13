using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Barrel : MonoBehaviour
{
    //The blast object that should be spawned
    public GameObject blast;

    //The bullet layer, which should set off the explosive barrel
    public LayerMask bullets;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //On collision, 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        LayerMask bullets = LayerMask.GetMask("Bullets");
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bullets")) 
        {
            Debug.Log("collision with bullets.");
            Instantiate(blast, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
