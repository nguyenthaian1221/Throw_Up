using HelperSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float LaunchForce;
    public GameObject bullet;
    public int angleInDegree;
    public Vector2 direction;

    public Transform curPos;
    public Transform targetPos;


    private Rigidbody2D rb;

    public bool grounded;


    //public float windForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {

        direction = GetDirection(angleInDegree);
        //LaunchForce = HelperMath.ResultForce(curPos.position, targetPos.position, angleInDegree);
        LaunchForce = HelperMath.ResultForceWithAirResistance(curPos.position, targetPos.position, angleInDegree,CoreGameplay.Instance.windForce);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        //if (!grounded)
        //{
        //    transform.position = transform.position - new Vector3(0, Time.deltaTime * 3, 0);
        //}
    }

    private void FixedUpdate()
    {
        Move();
    }



    private void Shoot()
    {
        GameObject ArrowIns = Instantiate(bullet, transform.position, transform.rotation);
        ArrowIns.GetComponent<Rigidbody2D>().AddForce(direction * LaunchForce);

    }


    public Vector2 GetDirection(int angle)
    {
        return HelperMath.EulerToVector(angle);
    }

    void Move()
    {
        var x_coordinate = new Vector2(InputManager.Instance.moveVector.x, 0);
        rb.position += x_coordinate * Time.fixedDeltaTime * 2;
    }


}
