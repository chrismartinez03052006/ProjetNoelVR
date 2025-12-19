using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OvenSocketChangePlate : MonoBehaviour
{
    [Header("Recette")]
    [SerializeField] private RecipeManager recipeManager;
    [SerializeField] private int stepIndex = 0;

    [Header("Socket")]
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    [Header("Condition")]
    [SerializeField] private string requiredTag = "Plat";

    [Header("Comportement")]
    [SerializeField] private bool disableSocketAfterSuccess = true;

    private bool done = false;

    private void Awake()
    {
        if (socket == null)
            socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (done) return;

        // ✅ Vérifie que c'est la bonne étape
        if (recipeManager != null && !recipeManager.CanDoStep(stepIndex))
            return;

        GameObject plate = args.interactableObject.transform.gameObject;

        // ✅ Vérifie que c'est bien un plat
        if (!string.IsNullOrEmpty(requiredTag) && !plate.CompareTag(requiredTag))
            return;

        // ✅ Change le modèle du plat, pas du four
        var swapper = plate.GetComponent<PlateModelSwapper>();
        if (swapper == null)
        {
            Debug.LogWarning("Le plat n'a pas PlateModelSwapper.");
            return;
        }

        done = true;

        swapper.SetCooked(true);

        // ✅ Valide l'étape de recette
        if (recipeManager != null)
            recipeManager.CompleteStep(stepIndex);

        if (disableSocketAfterSuccess)
            socket.enabled = false;
    }
}