using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLine : MonoBehaviour
{
    public List<Vector2> points;
    private MeshCollider mesh;
    //public pxStrax synths;
    // Start is called before the first frame update
    void Start()
    {   
        mesh = GetComponent<MeshCollider>();
        mesh.convex = true;
       // mesh.isTrigger = true;
     //   Debug.Log(points.Count);
    }

     void OnCollisionEnter(Collision collision)
     {
         Debug.Log("Yooo");
    //     //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "MyGameObjectName")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }


}
