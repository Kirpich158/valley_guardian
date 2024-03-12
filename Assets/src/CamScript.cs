using UnityEngine;

public class CamScript : MonoBehaviour {
    public GameObject targetToFollow;

    private float _followSpeed = 10f;
    private float _distance = 0f;

    void Start() {}

    void Update() {
        FollowTarget();
    }

    public void FollowTarget() {
        _distance = Vector3.Distance(transform.position, targetToFollow.transform.position);
        if (_distance > 0) {
            float distCovered = Time.deltaTime * _followSpeed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / _distance;

            // Set our position as a fraction of the distance between the markers.
            float newX = targetToFollow.transform.position.x;
            float newY = targetToFollow.transform.position.y;
            transform.position = Vector3.Lerp(transform.position, new Vector3(newX, newY, transform.position.z), fractionOfJourney);
        }

        // ==> WHY Vector3.Set() isn't working that way? <==
        // transform.position.Set(targetToFollow.GetComponent<Transform>().position.x, transform.position.y, targetToFollow.GetComponent<Transform>().position.z);
    }
}
