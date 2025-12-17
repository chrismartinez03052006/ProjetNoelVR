using UnityEngine;
using TMPro;

public class RecipeUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text recipeText;

    [Header("Recette")]
    [TextArea(2, 5)]
    public string[] steps;

    private int currentStep = 0;

    void Start()
    {
        if (steps.Length > 0)
        {
            recipeText.text = steps[currentStep];
        }
    }

    // Appelé quand une étape est validée
    public void NextStep()
    {
        currentStep++;

        if (currentStep < steps.Length)
        {
            recipeText.text = steps[currentStep];
        }
        else
        {
            recipeText.text = "Normalement on est bon la";
        }
    }
}