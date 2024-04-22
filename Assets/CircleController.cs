using UnityEngine;

public class CircleController : MonoBehaviour
{
    public CircleView View;

    void Start()
    {
        var rotationAmplitude = CirclePinger.Instance.RotationAmplitude;
        var scaleAmplitude = CirclePinger.Instance.ScaleAmplitude;
        var ringPeriod = CirclePinger.Instance.RingPeriod;
        View.SetRingAnimation(rotationAmplitude, scaleAmplitude, ringPeriod);
        
        var ringSound = CirclePinger.Instance.RingSound;
        View.SetSound(ringSound);
    }
    
    public void RingTheBell()
    {
        View.AnimateRing();
    }
}
