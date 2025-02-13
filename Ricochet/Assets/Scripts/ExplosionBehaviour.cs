using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField]
    float blastMaxAliveTime = 3f;

    float blastAliveTime = 0f;

    Rigidbody2D rb2D;

    public int bPIndex = 0;

    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (blastAliveTime >= blastMaxAliveTime)
        {
            Destroy(gameObject);
        }
        else
        {
            FadeOut();
            blastAliveTime += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<MovePlayer>().GetPlayerIndex() != bPIndex)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player"))
            {
                g.GetComponent<MovePlayer>().ResetPosition();
                Debug.Log($"Reset Player {g.GetComponent<MovePlayer>().GetPlayerIndex()}");
            }
        }
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFading()
    {
        StartCoroutine(FadeOut());
    }
}
