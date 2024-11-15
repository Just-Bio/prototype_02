using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
	public float DoorSpeed = 1f;
	public bool Closed = false;
	public Transform doorTransform = null;
	private Vector3 doorClosePos;
	public Vector3 doorOpenPos;

	private float _timeCounter;
	void Start()
	{
		doorClosePos = doorTransform.localPosition;
		_timeCounter = Closed ? 1.1f : 0f;
	}
	void Update()
	{
		if (_timeCounter < 1 && Closed)
		{
			_timeCounter += Time.deltaTime * DoorSpeed;
		}
		else if (_timeCounter > 0 && !Closed)
		{
			_timeCounter -= Time.deltaTime * DoorSpeed;
		}
		if (doorTransform != null)
		{
			doorTransform.localPosition = Vector3.Lerp(doorOpenPos, doorClosePos, _timeCounter);
		}
	}
	public void ToggleDoor()
	{
		Closed = !Closed;
	}

}
