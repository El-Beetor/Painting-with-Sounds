using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStrax : MonoBehaviour {
    public bool selected = false;
    public pxStrax[] synths;
    public int current = 0;
    public float Currentnote;
    private float[] notes = new float[] { 0, 2f, 3f, 5f, 7f, 8f, 10f, 12f };
    private int height;
    private int width;
    private float initialAttack;
     private float initialRelease;
      private float initialEvelope;
    // Use this for initialization
    void Start () {
         synths = GetComponentsInChildren<pxStrax>();
        height = Screen.height;
        width = Screen.width ;
        initialAttack = synths[0].attack;
         initialRelease = synths[0].release;
          initialEvelope = synths[0].envelope;
	}
	
	// Update is called once per frame
	void Update () {

        //  synths[0].attack = initialAttack;
        //  synths[0].release = initialRelease;
        //      synths[0].envelope = initialEvelope;
        if (Input.GetMouseButton(0)|| Input.GetMouseButtonDown(0))
        {
            if(MouseIsInBounds()){
                
            transform.position  =  Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f,0f,0f);
            
                //x axis is changes the notes y axis is changes the octave
            //float note_on = notes[(int)(Mathf.Floor((transform.position.x + 9f) * 2f) % 8f)] + Mathf.Floor(transform.position.y + 5) * 12f + 21;// +20f;
              //  Debug.Log(transform.position.y + 5);
               // float note_on = Mathf.Floor((transform.position.y + 5) * 2.4f) + 40;//- 69f;
                 float note_on = (transform.position.y + 5) * 2.4f + 48;//- 69f;
                //float note_on = Currentnote;
            Currentnote  = note_on;
            if (!selected)
            {
                //current = (current + 1) % 5;
                synths[current].KeyOn(note_on);
                selected = true;
            }
            else{
                synths[current].KeyOff();
                selected = false;
            }
            }
        }
        else
        {
            if (selected)
            {
                selected = false;
                synths[current].KeyOff();
            }
        }
    }

        bool MouseIsInBounds()
    {
        // The position is already relative to the texture so if it is >= to 0 and less then the texture
        // width and height it is in bounds.
        if(Input.mousePosition.x >= 0 && Input.mousePosition.x < width )
        {
            if (Input.mousePosition.y >= 0 && Input.mousePosition.y < height)
            {
                return true;
            };
        }
        return false;
    }
}
