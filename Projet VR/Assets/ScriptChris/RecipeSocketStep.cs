using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecipeSocketStep : MonoBehaviour
{
    [Header("Recette")]
    [SerializeField] private RecipeManager recipeManager;
    [SerializeField] private int stepIndex = 0;

    [Header("Socket")]
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    [Header("Condition (Tag de l'objet attendu)")]
    [SerializeField] private string requiredTag = "Aliment";

    [Header("Consommation de l'objet inséré")]
    [SerializeField] private bool consumeInsertedObject = true;

    [Header("Changement visuel (optionnel)")]
    [SerializeField] private GameObject modelAvant;
    [SerializeField] private GameObject modelApres;

    [Header("Optionnel : désactiver le socket après succès")]
    [SerializeField] private bool disableSocketAfterSuccess = true;

    private bool done = false;

    private void Awake()
    {
        if (socket == null) socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
        SetState(false);
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
        if (recipeManager != null && !recipeManager.CanDoStep(stepIndex)) return;

        var go = args.interactableObject.transform.gameObject;
        if (!string.IsNullOrEmpty(requiredTag) && !go.CompareTag(requiredTag)) return;

        done = true;

        // Visuel
        SetState(true);

        // Consommer ou pas
        if (consumeInsertedObject)
        {
            go.SetActive(false);
        }
        else
        {
            // Exemple: la cuillère, on la laisse vivre. 
            // dans une position précise si tu veux.
        }

        if (disableSocketAfterSuccess) socket.enabled = false;

        if (recipeManager != null) recipeManager.CompleteStep(stepIndex);
    }

    private void SetState(bool after)
    {
        if (modelAvant) modelAvant.SetActive(!after);
        if (modelApres) modelApres.SetActive(after);
    }
}
