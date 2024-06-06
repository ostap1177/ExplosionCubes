using UnityEngine;

[RequireComponent(typeof(Cube))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private ChanceCounter _chanceCounter;
    [SerializeField] private Material[] _materials;

    [SerializeField] private int _minCountCubes;
    [SerializeField] private int _maxCountCubes;
    [SerializeField] private int _splitterCube = 2;

    private Transform _transform;
    private Cube _cube;
    private int _countCreate;

    private void OnEnable()
    {
        _cube.Clecked += OnClicked;
    }

    private void OnDisable()
    {
        _cube.Clecked -= OnClicked;
    }

    private void Awake()
    {
        _transform = transform;
        _cube = GetComponent<Cube>();
    }

    private void OnClicked(Transform transform)
    { 
        CreateCubes(transform.localScale);
    }

    private void CreateCubes(Vector3 scale)
    {
        if (_chanceCounter.IsCreatedChance())
        {
            _countCreate = _cube.CountSplit;
            _countCreate++;

            int countCubes = Random.Range(_minCountCubes, _maxCountCubes);

            for (int i = 0; i < countCubes; i++)
            {
                Cube cube = Instantiate(_prefabCube, _transform.position, Quaternion.identity);
                cube.transform.localScale = scale / _splitterCube;
                cube.SetCountSplit(_countCreate);
                cube.GetComponent<Renderer>().material = ChangeColor();
                _explosion.SetChildCubesExplosion(cube);
            }

            _explosion.BlowingChildCube(_transform.position);
            _cube.DestroyCube();
        }
    }

    private Material ChangeColor()
    { 
        int index = Random.Range(0, _materials.Length);

        return _materials[index];
    }
}
