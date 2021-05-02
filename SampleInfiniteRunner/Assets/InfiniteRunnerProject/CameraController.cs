using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController : MonoBehaviour
    {
        private Runner runner = null;
        private Camera mainCam = null;

        public void SetRunner(Runner _runner)
        {
            runner = _runner;
            mainCam = FindObjectOfType<Camera>();
        }

        public void OnFixedUpdate()
        {
            mainCam.transform.position = new Vector3(runner.transform.position.x, 0f, runner.transform.position.z - 5f);
        }
    }
}