using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FearManager fearManager;

    [SerializeField] private SoundSystem soundSystem;
    [SerializeField] private LightSystem lightSystem;
    [SerializeField] private CameraSystem cameraSystem;
    [SerializeField] private MonsterSpawnerSystem monsterSpawnerSystem;

    private void Start()
    {
        fearManager.RegisterObserver(soundSystem);
        fearManager.RegisterObserver(lightSystem);
        fearManager.RegisterObserver(cameraSystem);
        fearManager.RegisterObserver(monsterSpawnerSystem);
        fearManager.SetFearLevel(0);
    }

    private void OnDestroy()
    {
        fearManager.RemoveObserver(soundSystem);
        fearManager.RemoveObserver(lightSystem);
        fearManager.RemoveObserver(cameraSystem);
        fearManager.RemoveObserver(monsterSpawnerSystem);
    }
}