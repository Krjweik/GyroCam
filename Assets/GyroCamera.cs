using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    private bool _gyroBool;

    private Gyroscope _gyro;

    private Quaternion _rotFix;

    public GameObject cube;

    /*public TouchLook touchLook;

    public UITexture popup;

    public Texture TouchTexture;

    public float IosGyroAngle;*/

    public void Start()
    {
        var parent = transform.parent;
        var camParent = new GameObject("GyroCamParent");
        camParent.transform.position = transform.position;
        transform.parent = camParent.transform;
        var camGrandParent = new GameObject("GyroCamGrandParent");
        camGrandParent.transform.position = transform.position;
        camParent.transform.parent = camGrandParent.transform;
        camGrandParent.transform.parent = parent;
        Input.gyro.enabled = true;

        if (!Input.gyro.enabled)
        {
            Debug.Log("cant enable gyro");
        }
        this._gyroBool = SystemInfo.supportsGyroscope;
        if (_gyroBool)
        {
            _gyro = Input.gyro;
            _gyro.enabled = true;
            camParent.transform.eulerAngles = new Vector3(90f, 180f, 0f);
            _rotFix = new Quaternion(0f, 0f, 1f, 0f);
        }
        else
        {
            /*this.popup.mainTexture = this.touchTexture;
            this.popup.MakePixelPerfect();
            this.touchLook.enabled = true;*/

            Debug.Log("supportsGyroscope - false");

            cube.SetActive(false);
        }
    }

    public void Update()
    {
        if (_gyroBool) //&& base.gameObject.GetComponent<>().enabled
        {
            _gyro = Input.gyro;
            var lhs = new Quaternion(_gyro.attitude.x, _gyro.attitude.y, _gyro.attitude.z, _gyro.attitude.w);
            transform.localRotation = lhs * _rotFix;
        }
    }
}