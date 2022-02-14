using UnityEngine;

public class Highlitable : MonoBehaviour
{
    [SerializeField] private Color highlightColor = Color.white;
    [SerializeField] private Renderer ownRenderer;

    private Color[] originalColors;

    private void Start()
    {
        if (ownRenderer == null) ownRenderer = GetComponent<Renderer>();
        StoreOriginalColor();
    }

    private void OnMouseEnter()
    {
        if (ownRenderer != null)
        {
            var materials = ownRenderer.materials;
            for (var i = 0; i < materials.Length; ++i) materials[i].color = highlightColor;
            ownRenderer.materials = materials;
        }
    }

    private void OnMouseExit()
    {
        if (ownRenderer != null)
        {
            var materials = ownRenderer.materials;
            for (var i = 0; i < materials.Length; ++i) materials[i].color = originalColors[i];
            ownRenderer.materials = materials;
        }
    }

    private void StoreOriginalColor()
    {
        if (ownRenderer != null)
        {
            var materials = ownRenderer.materials;
            originalColors = new Color[materials.Length];
            for (var i = 0; i < materials.Length; ++i) originalColors[i] = materials[i].color;
        }
    }
}