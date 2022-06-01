using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paint : MonoBehaviour
{
    public Material lineMaterial;
    public Color c1;
    public float widthLine = 1;
    public FlexibleColorPicker fcp;
    public Slider sil;
    public Transform Panel;
    public GameObject TheSynth;

    private Vector2 mousePosition;
    private Vector2 objPosition;

    private int width = 0;
    private int height = 0;

    private List<List<Vector2>> listPoints;
    //private List<Vector2> points;
    private List<GameObject> lines;
    private LineRenderer lr;
    private int NumLines = -1;
    // Start is called before the first frame update
    void Start()
    {   
        lines = new List<GameObject>();
        listPoints = new List<List<Vector2>>();
        height = Screen.height;
        width = 2*(int)Panel.position.x - Screen.width ;
       // CreateLine();
    }

    public void widthChange(){
       widthLine = sil.value;
       //widthLine = val;
    }
    
     public void ColorChange(){
        c1 = fcp.color;
       //Debug.Log("Hello");
   }

    void CreateLine(){
        NumLines++;
        GameObject myLine = new GameObject();
        myLine.AddComponent<LineRenderer>();
        lr = myLine.GetComponent<LineRenderer>();
        lr.material = lineMaterial;
        lr.startColor = c1;
        lr.endColor = c1;
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0f, -0.10f * widthLine);
        curve.AddKey(0.50f, .25f);
        curve.AddKey(1f, -0.10f * widthLine);
        lr.widthCurve = curve;
        lr.widthMultiplier = widthLine;
        lines.Add(myLine);
        List<Vector2> points = new List<Vector2>();
        listPoints.Add(points);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        DrawLine();
        
    }

     void HandleInput()
    {
        // Since we can only paint on the canvas if the mouse button is press
        // May be best to revise this so the tool has a call back for example a 
        // fill tool selected would call its own "Handle" method,
       
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            // We have input, lets convert the mouse position to be relative to the canvas
            mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
            objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
            // Checking that our mouse is in bounds, which is stored in our height and width variable and as long as it has a "positive value"
          //  if(Input.GetMouseButtonDown(0)){CreateLine();};

            if(MouseIsInBounds())
            {
             if(Input.GetMouseButtonDown(0)){CreateLine();};
             if(NumLines>-1){
               listPoints[NumLines].Add(objPosition);
             }
                //DrawLine(objPosition)
               // Instantiate(baseDot, objPosition, baseDot.rotation);
            }

           // Debug.Log(mousePosition);
        }

            if (Input.GetButtonUp("Fire1")){
                //Debug.Log("Fire");
                mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
                if(MouseIsInBounds()&&NumLines>-1&&listPoints[NumLines][0] != listPoints[NumLines][listPoints[NumLines].Count -1]){
                    // lines[NumLines].AddComponent<MeshCollider>();   
                    // MeshCollider meshCollider = lines[NumLines].GetComponent<MeshCollider>();      
                    // Mesh mesh = new Mesh();
                    // lr.BakeMesh(mesh, true);
                    // meshCollider.sharedMesh = mesh;
                    EdgeCollider2D collider2d = lines[NumLines].AddComponent<EdgeCollider2D>();  
                    //lines[NumLines].AddComponent<BoxCollider2D>();
                    // Mesh mesh = new Mesh();
                    // lr.BakeMesh(mesh, true);
                    // meshCollider.sharedMesh = mesh;
                    //Adds the scrpt PlayLine to the finished Line
                    lines[NumLines].AddComponent<PlayLine>();
                    lines[NumLines].GetComponent<PlayLine>().pointsV = listPoints[NumLines];
                    //lines[NumLines].AddComponent<AudioSource>();
                    //lines[NumLines].AddComponent<pxStrax>();
                     lines[NumLines].GetComponent<PlayLine>().TheSynth = TheSynth;
                     lines[NumLines].GetComponent<PlayLine>().c = c1;
                }
            }
    }

   
    bool MouseIsInBounds()
    {
        // The position is already relative to the texture so if it is >= to 0 and less then the texture
        // width and height it is in bounds.
        if(mousePosition.x >= 0 && mousePosition.x < width )
        {
            if (mousePosition.y >= 0 && mousePosition.y < height)
            {
                return true;
            };
        }
        return false;
    }



     void DrawLine()
             {
                 if(NumLines == -1) return;
                lr.startWidth = 0.1f;
                lr.endWidth = 0.1f; 
                 if(listPoints[NumLines].Count > 0){
                //lines[NumLines].transform.position = listPoints[NumLines][0];
                 lr.positionCount = listPoints[NumLines].Count;
                 for(int i = 0; i < listPoints[NumLines].Count; i++){
                     lr.SetPosition(i, listPoints[NumLines][i]);
                 };
                 };
                 //GameObject.Destroy(myLine, duration);
             }

    public void Undo(){
        //if(NumLines)
        Destroy(lines[lines.Count -1]);
        listPoints.RemoveAt(lines.Count -1);
        lines.RemoveAt(lines.Count -1);
        NumLines--;
        CreateLine();        
    }


}
