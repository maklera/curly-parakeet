using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Vector2 hotspot = new Vector2(16, 16); // Точка взаимодействия (центр текстуры)
    
    private void Start()
    {
        // Скрываем стандартный курсор
        Cursor.visible = true;
        
        // Устанавливаем новый курсор
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }
}
