using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLine : MonoBehaviour
{
    public List<Vector2> pointsV;
    public Vector2[] points;
    private EdgeCollider2D collider2d;
    public float interval = 0.001f;
    //private BoxCollider2D collider2d;
    public pxStrax synths;
    public  GameObject TheSynth;
    //private bool selected = false;
    private bool isTriggered = false;
    public Color c;
    //private float[] notes = new float[] { 0, 2f, 3f, 5f, 7f, 8f, 10f, 12f };
   // private float timePerNote = 0;
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
         //c = GetComponent<LineRenderer>().Color;
        // synths.distortion = 0.0f;
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
           // timePerNote += Time.deltaTime;
           //     interval = Time.deltaTime;
             //   if(timePerNote >= interval){
                    if( i < pointsV.Count){
                   // float note_on = Mathf.Floor((pointsV[i].y + 5) * 8.8f) + 21;
                      float note_on = (pointsV[i].y + 5) * 2.4f + 40;//- 69f;
                //    // timePerNote = 0;
                //     synths.KeyOff();
                //     synths.KeyOn(note_on);
               // float temp =TheSynth.GetComponent<pxStrax>().volume ;
               // TheSynth.GetComponent<pxStrax>().volume = c.a;//map(c.a,0,255,0.0f,1.0f);
                //Debug.Log(map(c.a,0,255,0,1));
                 //TheSynth.GetComponent<pxStrax>().Release = ;
                //  float attack = map(c.b, 0f,255f,0f,0.2f);
                //  float release = map(c.r, 0f,255f,0f,0.5f);
                //  float envelope = map(c.g, 0f,255f,0f,0.1f);
                //Debug.Log(c);
                TheSynth.GetComponent<PlayAllSounds>().PlayNote(note_on, c);
               // TheSynth.GetComponent<pxStrax>().volume = temp;
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
              //  }

   }
float map(float s, float a1, float a2, float b1, float b2)
{
    return b1 + (s-a1)*(b2-b1)/(a2-a1);
}

}
