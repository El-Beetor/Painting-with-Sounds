using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    // //public FlexibleColorPicker fcp;
    // public Paint script;
    // public GameObject mainSlider;

// }
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Paint : MonoBehaviour
// {
//     public Material lineMaterial;
//     public Color c1;
//     public float widthLine = 1;
//     public FlexibleColorPicker fcp;
//     public Slider sil;

//     private Vector2 mousePosition;
//     private Vector2 objPosition;

//     private int width = 0;
//     private int height = 0;

//     private List<List<Vector2>> listPoints;
//     //private List<Vector2> points;
//     private List<GameObject> lines;
//     private LineRenderer lr;
//     private int NumLines = -1;
//     // Start is called before the first frame update
//     void Start()
//     {   
//         lines = new List<GameObject>();
//         listPoints = new List<List<Vector2>>();
//         height = Screen.height;
//         width = Screen.width;
//        // CreateLine();
//     }

//     public void widthChange(float val){
//         Debug.Log(val);
//        //widthLine = val;
//     }
    
//      public void ColorChange(){
//         c1 = fcp.color;
//        //Debug.Log("Hello");
//    }

//     void CreateLine(){
//         NumLines++;
//         GameObject myLine = new GameObject();
//         myLine.AddComponent<LineRenderer>();
//         lr = myLine.GetComponent<LineRenderer>();
//         lr.material = lineMaterial;
//         lr.startColor = c1;
//         lr.endColor = c1;
//         AnimationCurve curve = new AnimationCurve();
//         curve.AddKey(0f, -0.10f * widthLine);
//         curve.AddKey(0.50f, .25f);
//         curve.AddKey(1f, -0.10f * widthLine);
//         lr.widthCurve = curve;
//         lr.widthMultiplier = widthLine;
//         lines.Add(myLine);
//         List<Vector2> points = new List<Vector2>();
//         listPoints.Add(points);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         HandleInput();
//         DrawLine();
        
//     }

//      void HandleInput()
//     {
//         // Since we can only paint on the canvas if the mouse button is press
//         // May be best to revise this so the tool has a call back for example a 
//         // fill tool selected would call its own "Handle" method,
       
//         if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
//         {
//             // We have input, lets convert the mouse position to be relative to the canvas
//             mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
//             objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
//             // Checking that our mouse is in bounds, which is stored in our height and width variable and as long as it has a "positive value"
//             if(MouseIsInBounds())
//             {
//              if(Input.GetMouseButtonDown(0)){CreateLine();};
//                listPoints[NumLines].Add(objPosition);
//                 //DrawLine(objPosition)
//                // Instantiate(baseDot, objPosition, baseDot.rotation);
//             }

//            // Debug.Log(mousePosition);
//         }

//             if (Input.GetButtonUp("Fire1")){
//                 //Debug.Log("Fire");
//                 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
//                 if(MouseIsInBounds()){
//                     MeshCollider meshCollider = lines[NumLines].AddComponent<MeshCollider>();                    
//                     Mesh mesh = new Mesh();
//                     lr.BakeMesh(mesh, true);
//                     meshCollider.sharedMesh = mesh;
//                 }
//             }
//     }

   
//     bool MouseIsInBounds()
//     {
//         // The position is already relative to the texture so if it is >= to 0 and less then the texture
//         // width and height it is in bounds.
//         if(mousePosition.x >= 0 && mousePosition.x < width - 100)
//         {
//             if (mousePosition.y >= 0 && mousePosition.y < height)
//             {
//                 return true;
//             };
//         }
//         return false;
//     }



//      void DrawLine()
//              {
//                  if(NumLines == -1) return;
//                 lr.startWidth = 0.1f;
//                 lr.endWidth = 0.1f; 
//                  if(listPoints[NumLines].Count > 0){
//                 //lines[NumLines].transform.position = listPoints[NumLines][0];
//                  lr.positionCount = listPoints[NumLines].Count;
//                  for(int i = 0; i < listPoints[NumLines].Count; i++){
//                      lr.SetPosition(i, listPoints[NumLines][i]);
//                  };
//                  };
//                  //GameObject.Destroy(myLine, duration);
//              }


}
