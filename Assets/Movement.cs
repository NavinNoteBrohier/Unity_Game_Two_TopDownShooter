using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float MaxSpeed;
    private float Speed;
    public float Range;
    //private int Behave;
    Quaternion Direction;
    Vector3 newDirection;
    bool move;

    private float MoveTmr = 0;
    private float DirTmr  = 0;

    // Use this for initialization
    void Start()
    {
        move = false;
     //   Direction = new Quaternion(0f,0f,0f,0f);
      

    }

    // Update is called once per frame
    void  Update ()
    {
        MoveTmr -= Time.deltaTime;
        DirTmr -= Time.deltaTime;

   //     Debug.Log(MoveTmr);

        if (DirTmr <= 0)
        {
            Debug.Log("Direction Timer");
            newDirection = new Vector3(Random.Range(0, 360+1), Random.Range(0, 360 + 1), Random.Range(0, 360 + 1));
            DirTmr = Random.Range(5, 6);
        }

           transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(newDirection), 0.01f);

        Debug.Log(Quaternion.Euler(newDirection));

        if (MoveTmr <= 0)
        {
            Debug.Log("Timer");
            int Behave = Random.Range(0, 2);
            Debug.Log(Behave);
            if (Behave == 0) 
            {
                Debug.Log("STOP");
                move = false;
                MoveTmr = Random.Range(1, 3);
            }
            else
            {
                Debug.Log("GO");
                move = true;
                Speed = Random.Range(1, MaxSpeed+1);
                MoveTmr = Random.Range(5, 7);
            }
                
        }

        if (move)
        {
            transform.position += Vector3.one * Speed * Time.deltaTime;

        }


       
        
	}
}
