using UnityEngine;
using System.Collections;

public class DOORSCRIPT : MonoBehaviour {

    public int KillCount; 

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(KillCount <= 0)
        {
            gameObject.SetActive(false);
        }
	}
}
