using UnityEngine;

[ExecuteInEditMode]
public class Stick : MonoBehaviour
{
    private GameManager _gameManager;
    
    public ParticleSystem particleSystem;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.AddPoint();
        particleSystem.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        _gameManager.RemovePoint();
    }
}
