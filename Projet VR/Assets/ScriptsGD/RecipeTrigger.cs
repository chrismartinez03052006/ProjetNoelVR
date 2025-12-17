using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecipeStepTrigger : MonoBehaviour
{
    public RecipeUI recipeUI;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool stepDone = false;

    void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (stepDone) return;

        stepDone = true;
        recipeUI.NextStep();
    }
}