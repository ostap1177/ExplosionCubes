using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TryGetHitCube(out Cube cubeHit)) 
            {
                cubeHit.ClickOn();
            }
        }
    }

    private bool TryGetHitCube(out Cube cubeHit)
    {
        cubeHit = null;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);

        foreach (var raycastHit in raycastHits)
        {
            if (raycastHit.transform.TryGetComponent<Cube>(out Cube cube))
            {
                cubeHit = cube;
            }
        }

        return cubeHit != null;
    }
}
