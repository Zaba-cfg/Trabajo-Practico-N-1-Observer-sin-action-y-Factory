using TMPro;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        timerText.text = $"Time: {timer:0}";
    }
}