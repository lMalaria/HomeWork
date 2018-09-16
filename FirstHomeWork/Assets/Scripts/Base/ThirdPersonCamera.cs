using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField]
    private Vector3 cameraOffset;

    [SerializeField]
    private float damping;

    Transform player;
    Transform cameraLookTarget;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        cameraLookTarget = GameObject.Find("Player").transform.Find("CameraLookTarget");
    }

    void Update()
    {
        Vector3 targetPosition = cameraLookTarget.position + player.forward * cameraOffset.z + player.up * cameraOffset.y + player.right * cameraOffset.x;
        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(this.transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, damping * Time.deltaTime);
    }
}
