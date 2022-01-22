using System;
using UnityEngine;

public class EventScript : MonoBehaviour 
{ 
    private event Action OnStart = delegate { };
    private event Action OnEnd = delegate { };

    [SerializeField]
    private GameObject start;
    [SerializeField]
    private GameObject end;

    private void Start() {
        OnStart += StartMethod;
        OnEnd += EndMethod;
    }

    private void StartMethod() {
        start.SetActive(true);
    }

    private void EndMethod() {
        end.SetActive(true);
    }

    public void ExecuteStart() {
        OnStart();
    }

    public void ExecuteEnd() {
        OnEnd();
    }
}
