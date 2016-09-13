using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody CapRigid;
    public float Speed;
    Vector3 Velocity;
    Vector3 Movement;
    private float CamRaylength = 500f;
    int FloorMask;

    private float ConSpeed;
    private float TopSpeed;
    public GameObject Aiming;


    // Use this for initialization
    void Awake()
    {
        FloorMask = LayerMask.GetMask("Floor");
        ConSpeed = Speed;
        TopSpeed = ConSpeed * 2;
    }
    void Start ()
    {
        Velocity = new Vector3(Speed, Time.deltaTime);
	}
	 
	// Update is called once per frame
	void FixedUpdate ()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Dash();

    }

    void Move(float h, float v)
    {
        Movement.Set(h, 0f, v);

        Movement = Movement.normalized * Speed * Time.deltaTime;

        CapRigid.MovePosition(transform.position + Movement);

        if(Input.GetKeyUp(KeyCode.Space))
        {
            CapRigid.AddForce(new Vector3(1, 10, 1), ForceMode.Impulse);
        }
    }

    void Turning()
    {
        Ray CamRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorhit;
        Debug.DrawRay(CamRay.origin,CamRay.direction);


        if (Physics.Raycast(CamRay, out floorhit, CamRaylength, FloorMask))
        {
            Vector3 PlayerToMouse = floorhit.point - transform.position;
            PlayerToMouse.y = 0f;

        //    Aiming.transform.position = floorhit.point;
            Vector3 A = new Vector3(floorhit.point.x,1,floorhit.point.z);

            Aiming.transform.position = Vector3.Lerp(Aiming.transform.position,A,0.5f);

            Quaternion newRotation = Quaternion.LookRotation(PlayerToMouse);
            CapRigid.MoveRotation(newRotation);
        }
    }
    int what = 2;
    void Dash()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = TopSpeed * what;
        }
        else
        {
            Speed = ConSpeed;
        }

    }




}
