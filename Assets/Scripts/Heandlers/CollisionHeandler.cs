using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHeandler : MonoBehaviour {
    private MeshRenderer _currentMeshRenderer;
    private PlayerController _playerController;
    private Collider _currentCollider;

    private void Start() {
        GetComponents();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Obstacle")) {
            CrashSequence();
        }
    }
    
    private void CrashSequence() {
        Invoke(nameof(CrashResult), 0.5f);
        Invoke(nameof(ReloadScene), 1f);
    }
    
    private void ReloadScene() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void CrashResult() {
        _currentMeshRenderer.enabled = false;
        _playerController.enabled = false;
        _currentCollider.enabled = false;
    }
    
    private void GetComponents() {
        _currentMeshRenderer = GetComponent<MeshRenderer>();
        _playerController = GetComponent<PlayerController>();
        _currentCollider = GetComponent<Collider>();
    }
}
