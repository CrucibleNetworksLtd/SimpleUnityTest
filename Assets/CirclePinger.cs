using UnityEngine;

public class CirclePinger : MonoBehaviour
{
    public float RotationAmplitude = 15f; 
    public float ScaleAmplitude = 0.1f;   
    public float RingPeriod = 2f;         
    public AudioClip RingSound;          
    
    public static CirclePinger Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}
