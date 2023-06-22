using UnityEngine;

public class CullingMaskController : MonoBehaviour
{
    [SerializeField] LayerMask lightDimensionLayerMask;
    [SerializeField] LayerMask darkDimensionLayerMask;

    private void Awake() 
    {
        ShowLightObjects();
    }

    // Enable rendering of the ShowHideLayer
    public void ShowLightObjects()
    {
        Camera.main.cullingMask = lightDimensionLayerMask;
    
    }

    // Disable rendering of the ShowHideLayer
    public void ShowDarkObjects()
    {
        Camera.main.cullingMask = darkDimensionLayerMask;
    }
}
