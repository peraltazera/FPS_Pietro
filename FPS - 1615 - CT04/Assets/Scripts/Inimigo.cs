using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject inimigo;
    public Sprite inimigoIdle;
    public Sprite inimigoDead;
    public SpriteRenderer alien;
    public float timer = 0f;
    public bool respaw;
    public Transform player;

    void Start()
    {
        Respawn();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f && respaw)
        {
            respaw = false;
            Respawn();
        }
        transform.LookAt(player);
        //transform.Rotate(Vector3.right, 90);
    }

    public void DestroyRespaw()
    {
        respaw = true;
        timer = 0;
        alien.sprite = inimigoDead;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void Respawn()
    {
        Vector3 incremento = new Vector3(Random.Range(-48f, 48f), (float)1.5, Random.Range(-48f, 48f));

        inimigo.transform.position = incremento;

        alien.sprite = inimigoIdle;

        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
