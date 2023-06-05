using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector2 moveDir;
    [SerializeField] float zoomScroll, zoomSpeed, moveSpeed, rotateSpeed, padding;
    [SerializeField] bool rotate;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void LateUpdate()
    {
        Pointer();
        Zoom();
    }

    void Pointer()
    {
        transform.Translate((Vector3.forward * moveDir.y + Vector3.right * moveDir.x) * moveSpeed * Time.deltaTime, Space.World);
    }

    void Zoom()
    {
        transform.Translate(Vector3.forward * zoomScroll * zoomSpeed * Time.deltaTime, Space.Self);
    }

    void OnPointer(InputValue inputValue)
    {
        Vector2 mousePos = inputValue.Get<Vector2>();
        if (mousePos.x < padding)
            moveDir.x = -1;
        else if (mousePos.x > Screen.width - padding)
            moveDir.x = 1;
        else
            moveDir.x = 0;

        if (mousePos.y < padding)
            moveDir.y = -1;
        else if (mousePos.y > Screen.height - padding)
            moveDir.y = 1;
        else
            moveDir.y = 0;
    }

    void OnZoom(InputValue inputValue)
    {
        zoomScroll = inputValue.Get<Vector2>().y;
    }
}
