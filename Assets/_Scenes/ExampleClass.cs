// Write black pixels onto the GameObject that is located
// by the script. The script is attached to the camera.
// Determine where the collider hits and modify the texture at that point.
//
// Note that the MeshCollider on the GameObject must have Convex turned off. This allows
// concave GameObjects to be included in collision in this example.
//
// Also to allow the texture to be updated by mouse button clicks it must have the Read/Write
// Enabled option set to true in its Advanced import settings.

using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    // Attach this script to a camera and it will paint black pixels in 3D
    // on whatever the user clicks. Make sure the mesh you want to paint
    // on has a mesh collider attached.

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Only when we press the mouse
        if (!Input.GetMouseButton(0))
        {
            return;
        }

        // Only if we hit something, do we continue
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            return;
        }

        // Just in case, also make sure the collider also has a renderer
        // material and texture. Also we should ignore primitive colliders.
        Renderer rend = hit.transform.GetComponent<Renderer>();

        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null ||
            rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            return;
        }

        // Now draw a pixel where we hit the object
        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord2;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        tex.SetPixel(Mathf.FloorToInt(pixelUV.x), Mathf.FloorToInt(pixelUV.y), Color.black);

        tex.Apply();
    }
}