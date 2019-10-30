using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque2 : MonoBehaviour {

    public float forcahorizontal = 15;
    public float forcavertical = 10;
    public float tempodedestruicao = 1;
    float focehoripadrao;


    void Start()
    {
        focehoripadrao = forcahorizontal;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monstros"))
        {
            other.gameObject.GetComponent<Boladepapel>().enabled = false;
            BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            if (other.transform.position.x < transform.position.x)
                forcahorizontal *= 1;

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcahorizontal, forcavertical), ForceMode2D.Impulse);

            Destroy(other.gameObject, tempodedestruicao);

            forcahorizontal = focehoripadrao;
        }
    }
}

