using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    private Transform _transform;

    public event UnityAction<Transform> Clecked;
    public int CountSplit { get; private set; }

    private void Awake()
    {
        _transform = transform;
    }

    public void ClickOn()
    {
        Clecked?.Invoke(_transform);
    }

    public void SetCountSplit(int count)
    {
        CountSplit += count;
    }

    public void DestroyCube()
    {
        Destroy(gameObject);
    }
}
