using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    public double frequency = 440.0;
    private double increment;
    private double phase;
    private double sampling_frequency = 48000.0;

    public float gain;
    float H;
    void Start(){
        H = (float)Screen.height;
        //Debug.Log("Screen Height : " + Screen.height);
    }
    void Update(){
        // if(Input.mousePosition.y>0 &&Input.mousePosition.y<H){
        // frequency = map(Input.mousePosition.y, 0, H, 100,880);
        //  //Debug.Log(q);
        // }
        //Debug.Log(q);
    }

    void OnAudioFilterRead(float[] data, int channels){
        increment = frequency * 2.0 * Mathf.PI / sampling_frequency;

        for(int i= 0; i < data.Length; i += channels){
            phase += increment;
            data[i] = (float)(gain * (Triangle((float)phase)));

            if(channels == 2)
            {
                data[i + 1] = data[i];
            }
            if(phase > (Mathf.PI * 2))
            {
                phase = 0.0;
            }
        }
    }

float SineWave(float In){
    return Mathf.Sin(In);
}
float Square(float In)
{
    if(gain * SineWave(In) >= 0 * gain){
        return 0.6f;
    }
    else return -0.6f;
}
float Triangle(float In){
    return Mathf.PingPong(In, 1.0f);
}

    float map(float s, float a1, float a2, float b1, float b2)
{
    return b1 + (s-a1)*(b2-b1)/(a2-a1);
}
 
}
