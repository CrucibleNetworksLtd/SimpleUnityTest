using UnityEngine;

public class CirclePonger : MonoBehaviour
{
    public float RotationAmplitude = 10f; 
    public float ScaleAmplitude = 0.05f;   
    public float RingPeriod = 2.5f;         
    public AudioClip RingSound;          
    
    public static CirclePonger Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
}