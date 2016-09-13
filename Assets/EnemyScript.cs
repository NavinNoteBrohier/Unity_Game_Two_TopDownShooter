using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public int Health;
    private float tmr = 5;
    int BulletMask;
    public GameObject Door;

    // Use this for initialization
    void Start()
    {
        BulletMask = 10;
        GetComponent<Light>().range = Health / 10;
        GetComponent<Light>().intensity = Health;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Behave();

        if (Health <= 0)
        {
            if (tmr <= 0)
            {
                gameObject.SetActive(false);
                try { Door.GetComponent<DOORSCRIPT>().KillCount--; }
                catch { }
            }

            GetComponent<Rigidbody>().freezeRotation = false;
            GetComponent<Rigidbody>().AddExplosionForce(50, transform.position, 5);

        }
        tmr -= Time.deltaTime;

    }

    void Behave()
    {

    }

    void OnCollisionEnter(Collision COLLIDING)
    {
        Debug.Log("Colliding" + COLLIDING.gameObject.layer);
        Debug.Log("LayerMask" +BulletMask);
        if (COLLIDING.gameObject.layer == BulletMask)
        {
            Health -= 5;
            GetComponent<Light>().intensity = Health;
            GetComponent<Light>().range = Health / 10; 
        }
    }
}
