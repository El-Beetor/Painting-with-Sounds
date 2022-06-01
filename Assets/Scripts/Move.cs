using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Move : MonoBehaviour
{
    //public Transform T;
    // Start is called before the first frame update
    private bool playing = false;
    private float speed;
     public Slider sil;
    void Start()
    {
        speed = sil.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(playing){
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            if(transform.position.x > 7){
                transform.position =new Vector3(-11, 0, 0);
            }
        }
    }

    public  void Play(){
        if(!playing){playing = true;}
        else { playing = false;}
    }
    public  void ChangeSpeed(){
      speed = sil.value;
    }
}
