using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Moving")]
    public float speed = 10f;
    public float xRange = 10f;
    public float yRange = 10f;

    [Header("Rotating")]
    public float positionPitchFactor = -2f;
    public float controllPitchFactor = -10f;
    public float controllRollFactor = -10f;
    public float positionYawFactor = 5f;

    [Header("Fire")]
    public GameObject[] lasers;
    
    private Transform _transform;
    private float _horizontal = 0;
    private float _vertical = 0;

    private void Start() {
        _transform = GetComponent<Transform>();
    }
    
    private void Update() {
        PlayerInput();

        PlayerMoving();
        PlayerRotation();
        PlayerFiring();
    }
    
    private void PlayerInput() {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }
    
    private void PlayerRotation() {
        Quaternion localRotation = _transform.localRotation;
        Vector3 localPosition = _transform.localPosition;
        
        float pitch = localPosition.y * positionPitchFactor + _vertical * controllPitchFactor;
        float yaw = localPosition.x * positionYawFactor;
        float roll = _horizontal * controllRollFactor;
        
        localRotation = Quaternion.Euler(pitch, yaw, roll);
        _transform.localRotation = localRotation;
    }
    
    private void PlayerMoving() {
        Vector3 localPosition = _transform.localPosition;
        
        float localPosX = localPosition.x;  
        float localPosY = localPosition.y;
        float localPosZ = localPosition.z;

        float clampPosX = ClampPosition(localPosX, xRange, _horizontal);
        float clampPosY = ClampPosition(localPosY, yRange, _vertical);
        
        localPosition = new Vector3(clampPosX, clampPosY, localPosZ);
        _transform.localPosition = localPosition;
    }
    
    private void PlayerFiring() {
        if (Input.GetKey(KeyCode.Space)) {
            SetActivateLaser(true);
        } else {
            SetActivateLaser(false);
        }
    }
    
    private void SetActivateLaser(bool isActive) {
        foreach (var laser in lasers) {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }   
    }

    private float ClampPosition(float localPos, float range, float moveDirection) {
        float rawPos = localPos + (moveDirection * speed) * Time.deltaTime;
        float clampPos = Mathf.Clamp(rawPos, -range, range);
        return clampPos;
    }
}
