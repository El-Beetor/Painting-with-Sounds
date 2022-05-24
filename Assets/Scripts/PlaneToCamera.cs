using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 2);
         Camera cam = Camera.main;
        Vector3 scale = transform.localScale;
        scale.y = 2f * cam.orthographicSize;
        scale.x  = cam.aspect;
        transform.localScale = scale;
    }

}
