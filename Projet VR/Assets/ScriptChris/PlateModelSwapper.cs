using UnityEngine;

public class PlateModelSwapper : MonoBehaviour
{
    [SerializeField] private GameObject modelAvant;
    [SerializeField] private GameObject modelApres;

    public void SetCooked(bool cooked)
    {
        if (modelAvant) modelAvant.SetActive(!cooked);
        if (modelApres) modelApres.SetActive(cooked);
    }
}