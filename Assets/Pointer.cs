using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    private Image crosshairImage;

    private void Start()
    {
        Cursor.visible = false;
        
        if (crosshairImage == null)
            crosshairImage = GetComponent<Image>();
    }

    private void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        crosshairImage.rectTransform.position = mousePosition;
    }
}
