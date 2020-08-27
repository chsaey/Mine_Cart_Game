using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryExplosion : MonoBehaviour
{
    public int cherryValue = 1;
    public bool taken = false;
    public GameObject explosion;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !taken) {
            taken = true;

            if (explosion)
            {
                Instantiate(explosion, transform.position, explosion.transform.rotation);
            }
            Object.Destroy(gameObject);
        }
    }
}
