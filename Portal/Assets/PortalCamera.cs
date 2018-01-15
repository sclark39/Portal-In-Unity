using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Camera playerCamera;

	public Transform portal;
	public Transform otherPortal;
	
	// Update is called once per frame
	void Update ()
	{
		Camera me = GetComponent<Camera>();
		me.fieldOfView = playerCamera.fieldOfView;

		Vector3 playerOffsetFromPortal = otherPortal.InverseTransformPoint( playerCamera.transform.position );		
		transform.position = portal.TransformPoint( playerOffsetFromPortal );

		//Vector3 playerDirectionOffsetFromPortal = otherPortal.InverseTransform( playerCamera.transform.forward );
		//transform.forward = portal.TransformDirection( playerDirectionOffsetFromPortal );
		Quaternion relative = Quaternion.Inverse( otherPortal.transform.rotation ) * playerCamera.transform.rotation;
		transform.rotation = portal.transform.rotation * relative;
		
		/*float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.transform.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
		*/
	}
}
