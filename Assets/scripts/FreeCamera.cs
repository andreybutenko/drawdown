﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace FreeCamera
{
	public class FreeCamera : MonoBehaviour
	{

	    public static FreeCamera instance = null;

		private float m_deltX = 45f;
		private float m_deltY = 0f;
		public float m_distance = 10f;

	    public bool CanCtrl = true;
		private float m_mSpeed = 2f;
		private Vector3 m_mouseMovePos = Vector3.zero;

	    void Awake()
	    {
	        instance = this;
	    }

		void Start()
		{
			
		}

		void Update () {
			/*if (Input.GetMouseButton(1))
			{
				m_deltX += Input.GetAxis("Mouse X") * m_mSpeed;
				m_deltY -= Input.GetAxis("Mouse Y") * m_mSpeed;
				m_deltX = ClampAngle(m_deltX, -360, 360);
				m_deltY = ClampAngle(m_deltY, -60, 60);
				GetComponent<Camera>().transform.rotation = Quaternion.Euler(m_deltX, m_deltY, 0);
			}*/
            if (!CanCtrl)
            {
                return;
            }
            if (Input.GetMouseButton(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    // Debug.Log("UI is clicked, return true");
                }
                else
                {
                    // Debug.Log("Nothing on UGUI is clicked, return false");
                    transform.Translate(Vector3.left * Input.GetAxis("Mouse X"));
                    transform.Translate(Vector3.down * Input.GetAxis("Mouse Y"));
                }
            }  
			if (Input.GetAxis("Mouse ScrollWheel") != 0)
			{
				m_distance = Input.GetAxis("Mouse ScrollWheel") * 10f;
				GetComponent<Camera>().transform.localPosition = GetComponent<Camera>().transform.position + GetComponent<Camera>().transform.forward * m_distance;
			}
				
		}
			
		float ClampAngle(float angle, float minAngle, float maxAgnle)
		{
			if (angle <= -360)
				angle += 360;
			if (angle >= 360)
				angle -= 360;

			return Mathf.Clamp(angle, minAngle, maxAgnle);
		}
	}
}
