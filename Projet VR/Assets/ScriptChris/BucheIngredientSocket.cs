using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BucheIngredientSocket : MonoBehaviour
{
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    [SerializeField] private GameObject modelAvant;
    [SerializeField] private GameObject modelApres;
    [SerializeField] private string ingredientTag;

    private bool ingredientDejaAjoute = false;

    private void Awake()
    {
        if (socket == null)
            socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();

        SetBucheState(false);
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnIngredientAjoute);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnIngredientAjoute);
    }

    private void OnIngredientAjoute(SelectEnterEventArgs args)
    {
        if (ingredientDejaAjoute) return;

        GameObject ingredient = args.interactableObject.transform.gameObject;

        if (!ingredient.CompareTag(ingredientTag)) return;

        ingredientDejaAjoute = true;

        // Change modèle bûche
        SetBucheState(true);

        // Fait disparaître B
        ingredient.SetActive(false);

        // Optionnel : empêche d'en mettre d'autres
        socket.enabled = false;
    }

    private void SetBucheState(bool avecIngredient)
    {
        if (modelAvant) modelAvant.SetActive(!avecIngredient);
        if (modelApres) modelApres.SetActive(avecIngredient);
    }
}