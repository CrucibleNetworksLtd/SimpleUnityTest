using System.Collections;
using UnityEngine;

public class CircleView : MonoBehaviour
{
    public AudioSource AudioSource;
    
    private float rotationAmplitude = 15f; // Degrees to jiggle rotation
    private float scaleAmplitude = 0.1f;   // Percentage to scale up/down
    private float ringPeriod = 2f;         // Time to complete one ring cycle in seconds

    private Vector3 initialScale;
    private Coroutine currentRingCoroutine;

    void Start()
    {
        initialScale = transform.localScale;
    }
    
    public void SetRingAnimation(float rotationAmplitude, float scaleAmplitude, float ringPeriod)
    {
        this.rotationAmplitude = rotationAmplitude;
        this.scaleAmplitude = scaleAmplitude;
        this.ringPeriod = ringPeriod;
    }
    
    public void SetSound(AudioClip sound)
    {
        AudioSource.clip = sound;
    }

    public void AnimateRing()
    {
        if (currentRingCoroutine != null)
        {
            StopCoroutine(currentRingCoroutine);  // Stop the current animation if it's running
            AudioSource.Stop();                     // Stop the sound as well
        }
        currentRingCoroutine = StartCoroutine(Ring());
        AudioSource.Play();
    }

    private IEnumerator Ring()
    {
        float elapsedTime = 0f;
        while (elapsedTime < ringPeriod)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / ringPeriod;
            float phase = Mathf.PI * 2 * progress;

            float scaleOffset = 1 + Mathf.Sin(phase) * scaleAmplitude;
            transform.localScale = initialScale * scaleOffset;

            float rotationOffset = Mathf.Sin(phase) * rotationAmplitude;
            transform.localRotation = Quaternion.Euler(0f, 0f, rotationOffset);

            yield return null;
        }

        transform.localScale = initialScale;
        transform.localRotation = Quaternion.identity;

        currentRingCoroutine = null;
    }
}
