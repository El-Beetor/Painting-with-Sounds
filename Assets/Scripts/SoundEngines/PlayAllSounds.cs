using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAllSounds : MonoBehaviour
{
   public bool selected = false;
    public float Currentnote;
    public pxStrax synths;
    private List<float> AllNotes = new List <float>();
     private List<Color> AllColors = new List <Color>();
    private bool playing;

    void Update(){
          if (AllNotes.Count >= 1 )
        {  
           
            float note_on = 0;
            // float AvgAttack = 0;
            // float AvgRelease = 0;
           // float AvgEnvelope = 0;
            for(int i = 0; i < AllNotes.Count; i ++){

             note_on += AllNotes[i] +
             map(AllColors[i].r + AllColors[i].g + AllColors[i].b, 0.0f, 3.0f, -12f, 24f);
           // AvgAttack += map(AllColors[i].r + AllColors[i].g + AllColors[i].b, 0.0f,3.0f,0.1f,1.0f);
           //  Debug.Log(AllColors[i][0] + AllColors[i][1] + AllColors[i][2]);
            // AvgRelease += map(AllColors[i].r, 0f,1f,0.1f,1f);
            //AvgEnvelope += map(AllColors[i].r + AllColors[i].g + AllColors[i].b, 0.0f, 3.0f, 0.8f, 0.12f);
            }
            note_on = (note_on / (float)(AllNotes.Count ));
            // Debug.Log(AvgAttack / (float)AllColors.Count);
            // Debug.Log(AllColors.Count);
            // synths.volume = AvgAttack / (float)AllColors.Count;
            // synths.release = AvgRelease / AllNotes.Count;
            // synths.envelope = AvgEnvelope / AllNotes.Count;
                //float note_on = Currentnote;
            Currentnote  = note_on;
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
        
          else
        {
            if (selected)
            {
                selected = false;
                synths.KeyOff();
            }
        }
        AllNotes = new List<float>();
        AllColors = new List<Color>();
    }

	public void PlayNote(float note, Color c) {

    AllNotes.Add(note);
    AllColors.Add(c);
    // Debug.Log("poo'" + AllNotes.Count);
    //  synths.KeyOn(note_on);
    // synths.KeyOff(); 
    }

    float map(float s, float a1, float a2, float b1, float b2)
{
    return b1 + (s-a1)*(b2-b1)/(a2-a1);
}


}
