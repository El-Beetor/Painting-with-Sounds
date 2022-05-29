using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLine : MonoBehaviour
{
    public List<Vector2> pointsV;
    public Vector2[] points;
    private EdgeCollider2D collider2d;
    public float interval = 0.01f;
    //private BoxCollider2D collider2d;
    public pxStrax synths;
    private bool selected = false;
    private bool isTriggered = false;
    //private float[] notes = new float[] { 0, 2f, 3f, 5f, 7f, 8f, 10f, 12f };
    private float timePerNote = 0;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
     {   
         //collider2d = this.GetComponent<BoxCollider2D>();
         points = pointsV.ToArray();
         collider2d   = this.GetComponent<EdgeCollider2D>(); 
         collider2d.points = points; 
         collider2d.isTrigger = true;
         synths = GetComponent<pxStrax>();
         synths.distortion = 0.0f;
    //     mesh = GetComponent<MeshCollider>();
    //     mesh.convex = true;
       // mesh.isTrigger = true;
     //   Debug.Log(points.Count);
    }
     
     void Update(){
         if(isTriggered){
             Triggered();
         }
     }

     void OnTriggerEnter2D(Collider2D collision)
     {      
            Debug.Log("Triggered");
        if (collision.gameObject.tag == "Player")
        {   
            Triggered();
            isTriggered = true;
      
        }

    }

    void Triggered(){
            timePerNote += Time.deltaTime;

                if(timePerNote >= interval){
                    if( i < pointsV.Count){
                    float note_on = Mathf.Floor((pointsV[i].y + 5) * 8.8f) + 21;
                    timePerNote = 0;
                    synths.KeyOff();
                    synths.KeyOn(note_on);
                    // if (!selected)
                    // {
                    //     synths.KeyOn(note_on);
                    //     selected = true;
                    // }
                    // else{
                    //     synths.KeyOff();
                    //     selected = false;
                    // }
                    i++;
                    }
                    else{                  
                        isTriggered = false;
                        i = 0;
                    }
                }

   }


}
