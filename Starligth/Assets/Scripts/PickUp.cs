using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public bool moveableObjectGrabbed = false;

    Ray moRay;
    public Transform moTransform;
    public LayerMask whatIsMoveableObject;
    RaycastHit moHit;

    public LayerMask whatIsGround;
    public Transform ground;
    RaycastHit groundHit;

    public Transform mousePosMarker;
    RaycastHit mousePosHit;
    public float moYOffsetFromGround = 0f;
    public float moPosOffsetFromGround = 0f;
    public Vector3 mousePosRelToGround;

    private void Start() {

        moHit = new RaycastHit();
        groundHit = new RaycastHit();
        mousePosMarker.gameObject.SetActive(false);
    }

    private void Update() {

        moRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetMouseButtonDown(0)) {
            FindAndGrabMoveableObject();
        }

        if(Input.GetMouseButtonUp(0)) {
            DropMoveableObject();
        }

        moveableObjectGrabbed = moTransform != null;
        mousePosMarker.gameObject.SetActive(moveableObjectGrabbed);

        if(moveableObjectGrabbed) {
            TraceMousePosRelativeToGround();
        }
    }

    void FindAndGrabMoveableObject() {

        if(Physics.Raycast(moRay, out moHit, Mathf.Infinity, whatIsMoveableObject)) {
            moTransform = moHit.transform;
            moTransform.GetComponent<Rigidbody>().isKinematic = true;
            FindGroundBelowMoveableObject();
        }  
    }

    void FindGroundBelowMoveableObject() {

        if (Physics.Raycast(moTransform.position, Vector3.down, Mathf.Infinity, whatIsGround)) {
            ground = groundHit.transform;
        }
    }

    void TraceMousePosRelativeToGround() {

        if(Physics.Raycast(moRay, out mousePosHit, Mathf.Infinity, whatIsGround)) {
            mousePosRelToGround = mousePosHit.point;
            moTransform.position = new Vector3(mousePosRelToGround.x,
                                               mousePosRelToGround.y + moYOffsetFromGround,
                                               mousePosRelToGround.z);
            mousePosMarker.position = new Vector3(mousePosRelToGround.x,
                                                  mousePosRelToGround.y + moYOffsetFromGround,
                                                  mousePosRelToGround.z);
        }
    }

    void DropMoveableObject() {

        if(moTransform != null) {
            moTransform.GetComponent<Rigidbody>().isKinematic = false;
            moTransform = null;
            ground = null;
        }
    }
}
