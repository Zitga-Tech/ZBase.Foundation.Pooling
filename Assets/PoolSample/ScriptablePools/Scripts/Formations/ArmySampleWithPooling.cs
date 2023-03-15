using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Foundation.Pooling.ScriptablePools;

public class ArmySampleWithPooling : MonoBehaviour
{
    private FormationBase _formation;

    public FormationBase Formation
    {
        get
        {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }

    //[SerializeField] private GameObject _unitPrefab;
    public ScriptableGameObjectPool pool;
    [SerializeField] private float _unitSpeed = 2;

    private readonly List<GameObject> _spawnedUnits = new List<GameObject>();
    private List<Vector3> _points = new List<Vector3>();
    private Transform _parent;
    

    private static readonly int s_isWalking = Animator.StringToHash("isWalking");

    private void Awake()
    {
        _parent = new GameObject("Unit Parent").transform;
        this.pool.Prefab.Parent = _parent;
        this.pool.Prepool(gameObject.GetCancellationTokenOnDestroy()).Forget();
        
    }

    private void Update()
    {
        SetFormation();
    }

    private void SetFormation()
    {
        _points = Formation.EvaluatePoints().ToList();

        if (_points.Count > _spawnedUnits.Count)
        {
            var remainingPoints = _points.Skip(_spawnedUnits.Count);
            Spawn(remainingPoints);
        }
        else if (_points.Count < _spawnedUnits.Count)
        {
            Kill(_spawnedUnits.Count - _points.Count);
        }

        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            _spawnedUnits[i].transform.position = Vector3.MoveTowards(_spawnedUnits[i].transform.position,
                transform.position + _points[i], _unitSpeed * Time.deltaTime);
            
            //face direction
            var direction = _spawnedUnits[i].transform.position - (transform.position + _points[i]);
            if (direction != Vector3.zero)
                _spawnedUnits[i].transform.rotation = Quaternion.LookRotation(-direction);
            
            //animation
            if (_spawnedUnits[i].transform.position != transform.position + _points[i])
            {
                var animator = _spawnedUnits[i].GetComponent<Animator>();
                animator.SetBool(s_isWalking, true);
                
            }
            else
            {
                var animator = _spawnedUnits[i].GetComponent<Animator>();
                animator.SetBool(s_isWalking, false);
            }
        }
    }

    private async void Spawn(IEnumerable<Vector3> points)
    {
        foreach (var pos in points)
        {
            var unit = await this.pool.Rent();
            unit.SetActive(true);
            unit.transform.position = transform.position + pos;
            _spawnedUnits.Add(unit);
        }
    }

    private void Kill(int num)
    {
        for (var i = 0; i < num; i++)
        {
            var unit = _spawnedUnits.Last();
            _spawnedUnits.Remove(unit);
            pool.Return(unit);
        }
    }
}