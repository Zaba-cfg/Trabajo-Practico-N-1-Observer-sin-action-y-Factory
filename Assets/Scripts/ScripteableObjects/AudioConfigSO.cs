using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "Game/Audio Config" )]
public class AudioConfigSO : ScriptableObject
{
    public List<AudioFearData> AudioFearData;
}