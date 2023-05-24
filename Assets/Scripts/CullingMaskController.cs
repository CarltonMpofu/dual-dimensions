using UnityEngine;

public class CullingMaskController : MonoBehaviour
{
    [SerializeField] LayerMask lightDimensionLayerMask;
    [SerializeField] LayerMask darkDimensionLayerMask;

    private void Awake() 
    {
        HideObjects();
    }

    // Enable rendering of the ShowHideLayer
    public void HideObjects()
    {
        Camera.main.cullingMask = lightDimensionLayerMask;
    
    }

    // Disable rendering of the ShowHideLayer
    public void ShowObjects()
    {
        Camera.main.cullingMask = darkDimensionLayerMask;
    }
}
