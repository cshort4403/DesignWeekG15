using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    float speed =5f;
    [SerializeField]
    int numBounces;

    Vector2 MoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		MoveDirection = transform.TransformDirection(MoveDirection);
		MoveDirection *= speed;
		transform.Translate(MoveDirection * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 moveDir)
    {
        MoveDirection = moveDir;
    }
}
