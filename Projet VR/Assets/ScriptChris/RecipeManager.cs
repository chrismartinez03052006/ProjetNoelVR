using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] private int currentStepIndex = 0;

    public bool CanDoStep(int stepIndex) => stepIndex == currentStepIndex;

    public void CompleteStep(int stepIndex)
    {
        if (stepIndex != currentStepIndex) return;
        currentStepIndex++;
        Debug.Log($" Étape {stepIndex} terminée. Prochaine étape: {currentStepIndex}");
    }
}
