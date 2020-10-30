using System;
using Android.Hardware.Camera2;

namespace CustomRenderer.Droid
{
    class CameraCaptureStateListener : CameraCaptureSession.StateCallback
    {
		public Action<CameraCaptureSession> OnConfigureFailedAction;
		public Action<CameraCaptureSession> OnConfiguredAction;

		public override void OnConfigureFailed(CameraCaptureSession session) => OnConfigureFailedAction?.Invoke(session);
		public override void OnConfigured(CameraCaptureSession session) => OnConfiguredAction?.Invoke(session);
	}
}
