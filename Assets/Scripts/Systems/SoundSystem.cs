using UnityEngine;

public class SoundSystem : MonoBehaviour, IFearSystemObserver
{
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioConfigSO audioConfig;

    public void OnFearChanged(float fearLevel)
    {
        FearAudioData data = GetAudioData(fearLevel);

        if (data == null)
        {
            return;
        }

        musicSource.volume = data.MusicVolume;
        musicSource.pitch = data.Pitch;
    }

    private FearAudioData GetAudioData(float fearLevel)
    {
        foreach (FearAudioData data in audioConfig.AudioSettings)
        {
            if (fearLevel >= data.MinFear && fearLevel <= data.MaxFear)
            {
                return data;
            }
        }

        return null;
    }
}