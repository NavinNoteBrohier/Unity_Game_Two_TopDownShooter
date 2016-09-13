using UnityEngine;
using System.Collections;

public class FollowingCameraScript : MonoBehaviour {
    public GameObject Target;

    public float LerpSpeed;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float tempy = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, LerpSpeed);
        transform.position =  new Vector3(transform.position.x,tempy,transform.position.z);
    }
}
