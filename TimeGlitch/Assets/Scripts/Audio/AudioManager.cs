using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;


    [Header("------------- Audio Clip -------------")]
    public AudioClip background;
    public AudioClip dialog;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = background;
        musicSource.volume = 0.2f;
        musicSource.Play();
    }

    //Sound effects
    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }

    public void StopSFX(AudioClip clip)
    {
        SFXsource.Stop();
    }

}
