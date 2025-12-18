using UnityEngine;
using TMPro;

public class RecipeUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text recipeText;

    [Header("Recette")]
    [TextArea(2, 5)]
    public string[] steps;

    [Header("Référence logique")]
    public RecipeManager recipeManager;

    private void Start()
    {
        if (steps.Length > 0)
            recipeText.text = steps[0];

        if (recipeManager != null)
            recipeManager.OnStepCompleted += UpdateUI;
    }

    private void OnDestroy()
    {
        if (recipeManager != null)
            recipeManager.OnStepCompleted -= UpdateUI;
    }

    private void UpdateUI(int stepIndex)
    {
        if (stepIndex < steps.Length)
            recipeText.text = steps[stepIndex];
        else
            recipeText.text = "shallah c bon ";
    }

    public void NextStep()
    {
        throw new System.NotImplementedException();
    }
}