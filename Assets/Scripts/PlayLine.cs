using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLine : MonoBehaviour
{
    public List<Vector2> pointsV;
    public Vector2[] points;
    private EdgeCollider2D collider2d;
    //private BoxCollider2D collider2d;
    public pxStrax synths;
    private bool selected;
    private float[] notes = new float[] { 0, 2f, 3f, 5f, 7f, 8f, 10f, 12f };
    private float timePerNote = 0;
    // Start is called before the first frame update
    void Start()
     {   
         //collider2d = this.GetComponent<BoxCollider2D>();
         points = pointsV.ToArray();
         collider2d   = this.GetComponent<EdgeCollider2D>(); 
         collider2d.points = points; 
         collider2d.isTrigger = true;
    //     mesh = GetComponent<MeshCollider>();
    //     mesh.convex = true;
       // mesh.isTrigger = true;
     //   Debug.Log(points.Count);
    }

     void OnTriggerEnter2D(Collider2D collision)
     {

        if (collision.gameObject.tag == "Player")
        {
            timePerNote += Time.deltaTime;
            if(timePerNote % 1 == 0){
            int L = 1;
            if((int)(Mathf.Floor((transform.position.x+9f) * 2f) % 8f) < 0 ){
                L = -1;
            }
                //x axis is changes the notes y axis is changes the octave
            float note_on = notes[(int)(Mathf.Floor((transform.position.x+9f) * 2f) % 8f) * L] + Mathf.Floor(transform.position.y + 2) * 12f;

            if (!selected)
            {
                //current = (current + 1) % 5;
                synths.KeyOn(note_on);
                selected = true;
            }
            else{
                synths.KeyOff();
                selected = false;
            }
            }
        }
         else if (selected){
             synths.KeyOff();
             selected = false;
         }
    }


}
