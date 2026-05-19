using System.Collections.Generic;
using UnityEngine;

public class FearManager : MonoBehaviour
{
    private readonly List<IFearSystemObserver> observers = new();

    [SerializeField]
    [Range(0f, 100f)]
    private float currentFearLevel;

    public float CurrentFearLevel => currentFearLevel;

    public void SetFearLevel(float newFearLevel)
    {
        currentFearLevel = Mathf.Clamp(newFearLevel, 0f, 100f);

        NotifyObservers();
    }

    public void RegisterObserver(IFearSystemObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void RemoveObserver(IFearSystemObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    private void NotifyObservers()
    {
        foreach (IFearSystemObserver observer in observers)
        {
            observer.OnFearChanged(currentFearLevel);
        }
    }
}