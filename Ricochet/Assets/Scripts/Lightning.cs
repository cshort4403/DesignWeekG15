using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;

    public float minWaitBetweenPlays = 10f;
    public float maxWaitBetweenPlays = 20f;
    public float waitTimeCountdown = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
