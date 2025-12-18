using UnityEngine;
using System;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] private int currentStepIndex = 0;

    public event Action<int> OnStepCompleted;

    public bool CanDoStep(int stepIndex) => stepIndex == currentStepIndex;

    public void CompleteStep(int stepIndex)
    {
        if (stepIndex != currentStepIndex) return;

        currentStepIndex++;

        // J'ai rajj ça chris si jamais 
        OnStepCompleted?.Invoke(currentStepIndex);

        Debug.Log($"Étape {stepIndex} terminée. Prochaine étape: {currentStepIndex}");
    }
}