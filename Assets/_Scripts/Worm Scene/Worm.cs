using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D bulletPrefab;
    [SerializeField]
    private Transform currentGun;


    public float walkSpeed = 1;
    public float maxRelativeVelocity = 6f;
    public float misileForce = 5f;

    public int wormID;

    private SpriteRenderer spriteRenderer;
    private Camera mainCam;

    private Vector3 diff;
    public bool IsTurn
    {
        get { return WormManager.Instance.IsMyTurn(wormID); }
    }
    private WormHealth wormHealth;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // get health script
        wormHealth = GetComponent<WormHealth>();    
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsTurn)
        {
            return;
        }
        RotateGun();

        MovementAndShooting();
    }

    void RotateGun()
    {
        diff = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_Z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        currentGun.rotation = Quaternion.Euler(0, 0, rot_Z + 180f);
    }

    void MovementAndShooting()
    {
        float hor = Input.GetAxis("Horizontal");

        if (hor == 0)
        {
            currentGun.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Rigidbody2D bullet = Instantiate(bulletPrefab,
                                                 currentGun.position - currentGun.right,
                                                 currentGun.rotation);

                bullet.AddForce(-currentGun.right * misileForce, ForceMode2D.Impulse);

                if (IsTurn)
                {
                    WormManager.Instance.NextWorm();
                }
            }
        }
        else
        {
            currentGun.gameObject.SetActive(false);

            transform.position += Vector3.right * hor * Time.deltaTime * walkSpeed;

            spriteRenderer.flipX = Input.GetAxis("Horizontal") > 0;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            wormHealth.ChangeHealth(-10);
            if (IsTurn)
            {
                WormManager.Instance.NextWorm();
            }
        }
    }
}
