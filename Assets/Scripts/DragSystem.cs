using UnityEngine;

public class DragSystem : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Camera mainCamera;
    private Vector3 originalPosition;
    private float fixedZ;

    private void Start()
    {
        mainCamera = Camera.main;
        originalPosition = transform.position;
        fixedZ = transform.position.z;

    }

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, .5f))
        {
            if (hit.collider.gameObject?.GetComponent<ISocket>() != null)
            {
                ISocket socket = hit.collider.GetComponent<ISocket>();
                socket.DetachCable();
            }
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
            Debug.DrawRay(transform.position, Vector3.forward,Color.red);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        ICable cable = GetComponent<ICable>();

        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, .5f))
        {
            ISocket targetSocket = hit.collider?.GetComponent<ISocket>();
            if (targetSocket != null)
            {
                if (cable != null && GameManager.Instance.TryConnect(cable,targetSocket))
                {
                    Vector3 newPosition = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y,fixedZ);
                    newPosition.y = Mathf.Clamp(newPosition.y, -0.4f, 5f);
                    transform.position = newPosition;
                    return;
                }
            }
        }
        cable.Disconnect();

        transform.position = originalPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }
}
