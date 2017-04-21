using UnityEngine;
using System.Collections;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	CameraShake: Shakes the camera.														*/
/*			HOW TO SET UP:																*/
/*				+	Create an empty GameObject.											*/
/*				+	Tag the newly created empty GameObject with "Camera"				*/
/*				+	Set MainCamera to be a child of the newly created GameObject		*/
/*																						*/
/*			HOW TO USE:																	*/
/*				+	CameraShake.CameraShakeEffect.Shake(0.1f, 0.25f);					*/
/*																						*/
/*		Functions:																		*/
/*			Start ()																	*/
/*			Shake (float amount, float lenght)											*/
/*			DoShake ()																	*/
/*			StopShake ()																*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class CameraShake : MonoBehaviour 
{
	//	Public Const Variables
	public const string CAMERA_SHAKE_TAG = "Camera";			//	Tag fo find the CameraShake.cs Script
																//	You can change the tag to whatever you want.
	
	public const string DO_SHAKE = "DoShake";					//	The name of the DoShake function
	public const string STOP_SHAKE = "StopShake";				//	The name of the StopShake function

	//	Public Variables
	public static CameraShake CameraShakeEffect;				//	Instance of the CameraShakeEffect
	public Camera mainCamera; 									//	Refernce to Main camera
	public float shakeAmount = 0;								//	How violent the shake is

	//	Private Variables
	private Vector3 endShakePosition = Vector3.zero;			//	Where the camera ends up after the shake
	//	Properties of endShakePositon variable
	public Vector3 EndShakePosition							
	{
		get { return endShakePosition;}
		set { endShakePosition = value;}
	}

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Start: Runs once at the begining of the game. Initalizes variables.					*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Start()
	{
		if (mainCamera == null)
		{
			mainCamera = Camera.main;
		}
		if (CameraShakeEffect == null)
		{
			CameraShakeEffect = GameObject.FindGameObjectWithTag (CAMERA_SHAKE_TAG).GetComponent<CameraShake> ();
		}
	}

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Shake: Starts the beginning of the shake											*/
	/*		param:	float amount - how violent the shake is									*/
	/*				float length - how many seconds the shake goes on for					*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	public void Shake(float amount, float length)
	{
		shakeAmount = amount;
		InvokeRepeating (DO_SHAKE, 0, 0.01f);
		Invoke (STOP_SHAKE, length);
	}

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	DoShake: The actual shaking happens here											*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void DoShake()
	{
		if (shakeAmount > 0)
		{
			Vector3 cameraPosition = mainCamera.transform.position;
			float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
			cameraPosition.x += offsetX;
			cameraPosition.y += offsetY;
			mainCamera.transform.position = cameraPosition;
		}
	}

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	StopShake: Stops the camera shaking													*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void StopShake()
	{
		CancelInvoke (DO_SHAKE);
		mainCamera.transform.localPosition = new Vector3(EndShakePosition.x, EndShakePosition.y, EndShakePosition.z);
	}		
}