using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraScript
    {
        public static CameraScript current = null;

        public BaseMessageHandler messageHandler = new CameraMessageHandler();

        IStateController<CameraState> _cameraStateController = null;
        GameObject _target = null;
        Camera _camera = null;

        public CameraScript()
        {
            current = this;
            _cameraStateController = new CameraStateController();
        }

        public void OnUpdate()
        {
            _cameraStateController.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            _cameraStateController.OnFixedUpdate();
            _cameraStateController.GetCurrentState().cameraUpdateCount++;

            //temp getting camera edges
            Vector3 topRight = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight, _camera.nearClipPlane));
            Vector3 topLeft = _camera.ScreenToWorldPoint(new Vector3(0f, _camera.pixelHeight, _camera.nearClipPlane));
            Vector3 bottomRight = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, 0f, _camera.nearClipPlane));
            Vector3 bottomLeft = _camera.ScreenToWorldPoint(new Vector3(0f, 0f, _camera.nearClipPlane));
            Debug.DrawLine(Vector3.zero, topRight, Color.yellow, 0.025f);
            Debug.DrawLine(Vector3.zero, topLeft, Color.yellow, 0.025f);
            Debug.DrawLine(Vector3.zero, bottomRight, Color.yellow, 0.025f);
            Debug.DrawLine(Vector3.zero, bottomLeft, Color.yellow, 0.025f);
        }

        public void OnLateUpdate()
        {
            _cameraStateController.OnLateUpdate();
            messageHandler.HandleMessages();
            messageHandler.ClearMessages();
        }

        public void SetCameraState(CameraState cameraState)
        {
            _cameraStateController.SetNewState(cameraState);
        }

        public void SetCamera(Camera camera)
        {
            _camera = camera;
        }

        public Camera GetCamera()
        {
            return _camera;
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public GameObject GetTarget()
        {
            return _target;
        }

        public void UpdateCameraPositionOnTarget(Vector3 pos)
        {
            _camera.transform.position = pos;
        }
    }
}