using UnityEngine;
using System.Collections;

public class GUNSCRIPT : MonoBehaviour {

    public GameObject Bullet;
    public GameObject Gun;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Shooting();

    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject temp = Instantiate(Bullet, new Vector3(Gun.transform.position.x, Gun.transform.position.y, Gun.transform.position.z), transform.rotation) as GameObject;
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * 25, ForceMode.Impulse);
        }
    }
}
