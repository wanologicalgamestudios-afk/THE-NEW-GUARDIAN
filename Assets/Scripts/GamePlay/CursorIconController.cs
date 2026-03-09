using UnityEngine;

public class CursorIconController : MonoBehaviour
{
    [SerializeField] private Texture2D cursosTextureDefault;


    [SerializeField] private Vector2 clickPosition = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.SetCursor(cursosTextureDefault, clickPosition, CursorMode.Auto);
    }

    public void ChangeCursorIcon(EnumsManager.CursorIcon cursorIcon)
    {
        switch (cursorIcon)
        {
            case EnumsManager.CursorIcon.Default:
                Cursor.SetCursor(cursosTextureDefault, clickPosition, CursorMode.Auto);
                break;
        }
    }
}
