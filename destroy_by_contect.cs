using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_by_contect : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private gameController gc;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("gameController");
        if (gameControllerObject != null)
        {
            gc = gameControllerObject.GetComponent<gameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Debug.Log("3");
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Debug.Log("1");
            gc.GameOver();
            Debug.Log("2");
        }
        gc.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
