using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Transform mainPoint;
    [SerializeField] float mainPointFactor;
    [SerializeField] Collider obstacleCollider;
    [SerializeField] bool isObstacleColliderOn =  true;

    Vector3 mainPointPosition;
    Vector3 playerPosition;

    public Vector3 MainPointPoition => mainPointPosition;
    public float MainPointFactor => mainPointFactor;

    private void Start()
    {
        obstacleCollider.enabled = isObstacleColliderOn;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            mainPointPosition =  mainPoint.position;
            playerPosition = other.transform.position;


            if (playerPosition.y > mainPointPosition.y) 
            {
                // move the obstacle to the front of the player
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, playerPosition.z + (-2));
            }
            else if (playerPosition.y < mainPointPosition.y) 
            {
                // move the obstacle to the back of the player
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, playerPosition.z + (2));
            }

        }
    }

    public void SetObstacleForNewGame() 
    {
        obstacleCollider.enabled = true;
    }
}
