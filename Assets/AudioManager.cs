using UnityEngine;

public class AudioManager : MonoBehaviour

{
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource effectAudioSource;

    [SerializeField] private AudioClip backGroundClip;
    [SerializeField] private AudioClip cookieClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip doroKillClip;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayBackGroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBackGroundMusic()
    {
        backgroundAudioSource.clip = backGroundClip;
        backgroundAudioSource.Play();
    }

    public void PlayCookieSound()
    {
        effectAudioSource.PlayOneShot(cookieClip);
    }

    public void PlayJumpSound()
    {
        effectAudioSource.PlayOneShot(jumpClip);
    }

    public void PlayWinSound()
    {
        effectAudioSource.PlayOneShot(winClip);
    }

    public void PlayDoroKillSound()
    {
        effectAudioSource.PlayOneShot(doroKillClip);
    }
}
