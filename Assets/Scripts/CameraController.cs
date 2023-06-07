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
        Boundary();
    }

    void Pointer()
    {
        transform.Translate((Vector3.forward * moveDir.y + Vector3.right * moveDir.x) * moveSpeed * Time.deltaTime, Space.World);
    }

    void Zoom()
    {
        transform.Translate(Vector3.forward * zoomScroll * zoomSpeed * Time.deltaTime, Space.Self);
    }

    void Boundary()
    {
        if (transform.position.x < -50f)
        {
            transform.position = new Vector3(-50f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 20f)
        {
            transform.position = new Vector3(20f, transform.position.y, transform.position.z);
        }

        if (transform.position.y < 20f)
        {
            transform.position = new Vector3(transform.position.x, 20f, transform.position.z);
        }
        else if (transform.position.y > 100f)
        {
            transform.position = new Vector3(transform.position.x, 100f, transform.position.z);
        }

        if (transform.position.z > 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
        else if (transform.position.z < -110f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -110f);
        }
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
