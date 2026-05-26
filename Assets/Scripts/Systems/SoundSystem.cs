using UnityEngine;

public class SoundSystem : MonoBehaviour, IFearSystemObserver
{
    [Header("References")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioConfigSO audioConfig;

    [Header("Transition")]
    [SerializeField] private float volumeTransitionSpeed = 3f;
    [SerializeField] private float pitchTransitionSpeed = 3f;

    private float targetVolume;
    private float targetPitch = 1f;

    private void Update()
    {
        SmoothAudio();
    }

    public void OnFearChanged(float fearLevel)
    {
        AudioFearData data = GetAudioFearData(fearLevel);

        if (data == null)
        {
            return;
        }

        targetVolume = data.MusicVolume;

        targetPitch = data.MusicPitch;
    }

    private void SmoothAudio()
    {
        musicSource.volume =
            Mathf.Lerp(
                musicSource.volume,
                targetVolume,
                volumeTransitionSpeed * Time.deltaTime
            );

        musicSource.pitch =
            Mathf.Lerp(
                musicSource.pitch,
                targetPitch,
                pitchTransitionSpeed * Time.deltaTime
            );
    }

    private AudioFearData GetAudioFearData(float fearLevel)
    {
        foreach (AudioFearData data in audioConfig.AudioFearData)
        {
            if (fearLevel >= data.MinFear && fearLevel <= data.MaxFear)
            {
                return data;
            }
        }

        return null;
    }
}