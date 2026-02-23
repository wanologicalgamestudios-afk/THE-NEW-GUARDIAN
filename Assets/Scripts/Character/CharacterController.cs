using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] Transform chatacter;
    [SerializeField] private Camera mainCamera;
    private Vector3 target;

    void Start()
    {
        target = chatacter.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            target = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            target.z = chatacter.position.z;
        }
        Move();
    }

    private void Move()
    {
        chatacter.position = Vector3.MoveTowards(chatacter.position, target, speed * Time.deltaTime);
    }
}
