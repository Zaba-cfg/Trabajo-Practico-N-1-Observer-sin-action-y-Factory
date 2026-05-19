using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FearGame/Audio Config")]
public class AudioConfigSO : ScriptableObject
{
    [field: SerializeField]
    public List<FearAudioData> AudioSettings { get; private set; }
}