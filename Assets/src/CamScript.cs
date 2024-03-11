using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject targetToFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    public void FollowTarget() {
        transform.position = new Vector3(
                targetToFollow.transform.position.x, 
                transform.position.y, 
                targetToFollow.transform.position.z
        );

        // ==> WHY Vector3.Set() isn't working that way? <==
        // transform.position.Set(targetToFollow.GetComponent<Transform>().position.x, transform.position.y, targetToFollow.GetComponent<Transform>().position.z);
    }
}
