using UnityEngine;
using System.Collections;

public class CURSOR : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 TwoTemp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Temp = new Vector3(TwoTemp.x, 1, TwoTemp.z);

        transform.position = Temp;
	}
}
