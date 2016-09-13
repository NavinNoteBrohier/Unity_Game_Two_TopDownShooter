using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    private float tmr = 10f;
    private float tmrtwo = 1f;
    bool Deleting = false;
    public GameObject Target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        tmr -= Time.deltaTime;

        if(Deleting == true)
        {
            tmrtwo -= Time.deltaTime;
        }

        if (tmr <= 0 || tmrtwo <= 0)
        {
            Target.SetActive(false);
        }

        

	}

    void OnCollisionEnter(Collision collider)
    {

        Deleting = true;

    }
}
