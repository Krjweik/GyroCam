using UnityEngine;

public class GyroLook : MonoBehaviour
{
    private bool _gyroBool;

    private Gyroscope _gyro;

    private Quaternion _rotFix;


    /*public TouchLook touchLook;

    public UITexture popup;

    public Texture TouchTexture;

    public float IosGyroAngle;*/

    public void Start()
    {
        var parent = transform.parent;
        var gyroParent = new GameObject("GyroParent");
        gyroParent.transform.position = transform.position;
        transform.parent = gyroParent.transform;
        var gyroGrandParent = new GameObject("GyroGrandParent");
        gyroGrandParent.transform.position = transform.position;
        gyroParent.transform.parent = gyroGrandParent.transform;
        gyroGrandParent.transform.parent = parent;

        Input.gyro.enabled = true;
        if (!Input.gyro.enabled)
        {
            Debug.Log("gyro: cant enable gyro");
        }

        this._gyroBool = SystemInfo.supportsGyroscope;
        if (_gyroBool)
        {
            _gyro = Input.gyro;
            _gyro.enabled = true;
            gyroParent.transform.eulerAngles = new Vector3(90f, 180f, 0f);
            _rotFix = new Quaternion(0f, 0f, 1f, 0f);
        }
        else
        {
            /*this.popup.mainTexture = this.touchTexture;
            this.popup.MakePixelPerfect();
            this.touchLook.enabled = true;*/

            Debug.Log("gyro: supportsGyroscope is false");
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