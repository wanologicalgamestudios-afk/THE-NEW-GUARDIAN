using UnityEngine;
using System.Collections;


public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField]
	private AudioSource backgroundAudioSource;
    [SerializeField]
	private AudioSource UISoundAudioSource;
    [SerializeField]
    private AudioSource sfxAudioSource;

    [Header("Audio Clip")]
    [SerializeField]
    private AudioClip backgroungMusic;
    [SerializeField]
    private AudioClip buttonClickSound;
    [SerializeField]
    private AudioClip legionaryAttackOneSound;
    [SerializeField]
    private AudioClip DrakonAttackOneSound;


    private bool isSoundOn = true;
    private bool isMusicOn = true;


    private void Awake()
    {
        CheckStatus();
    }

	private void CheckStatus() 
	{
		if (IsSoundOn == 1)
		{
            isSoundOn = true;
		}
		else 
		{
            isSoundOn = false;
        }

		if (IsMusicOn == 1) 
		{
            isMusicOn = true;
		}
		else 
		{
            isMusicOn = false;
        }
    }

    private void PlaySound(AudioClip clip, AudioSource audioOut)
    {
        if (!isSoundOn || clip == null || audioOut == null) return;

        audioOut.clip = clip;
        audioOut.Play();
    }

	private void PlayMusic(AudioClip clip, AudioSource audioOut)
    {
        if (!isMusicOn || clip == null || audioOut == null) return;

        audioOut.clip = clip;
        audioOut.Play();
    }

	public void PlayButtonClickSound()
	{
        PlaySound(buttonClickSound, UISoundAudioSource);
    }
    public void PlayLegionaryAttackOneSound()
    {
        PlaySound(legionaryAttackOneSound, sfxAudioSource);
    }
    public void PlayDrakonAttackOneSound()
    {
        PlaySound(DrakonAttackOneSound, sfxAudioSource);
    }
    public void PlayBackgroundMusic()
    {
        PlayMusic(backgroungMusic, backgroundAudioSource);
    }
    public void PlaySfx(AudioClip clip)
    {
        PlaySound(clip, sfxAudioSource);
    }

    public int IsSoundOn
    {
        get { return PlayerPrefs.GetInt("isSoundOn", 1); }
        set { PlayerPrefs.SetInt("isSoundOn", value); }
    }
    public int IsMusicOn
    {
        get { return PlayerPrefs.GetInt("isMusicOn", 1); }
        set { PlayerPrefs.SetInt("isMusicOn", value); }
    }


}
