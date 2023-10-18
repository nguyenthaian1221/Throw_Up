using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera cam;

    [SerializeField]
    private Vector3 _offset;

    [SerializeField]
    private float _damping;

    private Vector3 vel = Vector3.zero;

    public Transform target;
    public Vector3 sizeOfCam;
    private Vector3 tempPos;
    private Vector3 mapSize;

    private void Start()
    {
        cam = Camera.main;
        sizeOfCam = cam.ViewportToWorldPoint(new Vector2(1f, 1f));
        mapSize = Map.Instance.SizeOfBackground;
    }

    private void FixedUpdate()
    {
        FollowTarget(target);
    }


    private void FollowTarget(Transform target)
    {
        tempPos.x = Mathf.Clamp(target.position.x, -11, 11);
        tempPos.y = Mathf.Clamp(target.position.y, -10, 10);
        tempPos.z = -10;
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, tempPos, ref vel, _damping);

    }
}
