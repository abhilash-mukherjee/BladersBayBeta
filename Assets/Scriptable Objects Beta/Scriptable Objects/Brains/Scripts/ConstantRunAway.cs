using UnityEngine;

[CreateAssetMenu(fileName = "New Run Away Movement Brain ", menuName = "AI Brains / Movement Brain / Run Away")]
public class ConstantRunAway : MovementBrain
{
    [SerializeField]
    private int fieldOfViewWhenInBoundary, fieldOfViewWhenCloseToPlayer, fieldOfViewWhenFarFromPlayer, marginOfErrorWhileAttacking;
    [SerializeField]
    private float thresholdDistance;
    [SerializeField]
    private float stadiumRadius = 2.32f;
    [SerializeField]
    private int playerFarCallingRate = 5;
    [SerializeField]
    private int playerNearCallingRate = 1;
    public override Vector3 GetMoveDir(GameObject playerObject, GameObject enemyObject,Transform stadiumCentre, Vector3 previousDir)
    {
        Vector3 _enemyPos = enemyObject.transform.position;
        Vector3 _playerPos = playerObject.transform.position;
        float _dist = (_enemyPos - _playerPos).magnitude;
        bool _isTooClose = _dist <= thresholdDistance ? true : false;
        bool _isOverLAppingWithStadum = IsOverlappingWithStadium(_playerPos, stadiumCentre);
        int m_callingRate = _isTooClose || _isOverLAppingWithStadum ? playerNearCallingRate : playerFarCallingRate;
        if (_isOverLAppingWithStadum)
        {
            Vector3 _newMoveDir = MoveAwayFromStadiumBoundary(_playerPos, stadiumCentre);
            return _newMoveDir;
        }
        else 
        { 

            if (_dist <= thresholdDistance)
            {
                    return MoveAwayFromEnemyWhenFar(_enemyPos, _playerPos);
            }
            else
            {
                return previousDir;
            }
        }
    }
    private Vector3 MoveAwayFromEnemyWhenFar(Vector3 _enemyposition, Vector3 _playerPosition)
    {
        Vector3 _baseDir = (_enemyposition - _playerPosition).normalized;
        int _angle = UnityEngine.Random.Range(-fieldOfViewWhenFarFromPlayer / 2, fieldOfViewWhenFarFromPlayer / 2);
        return Quaternion.AngleAxis(_angle, Vector3.up) * _baseDir;
    }
    private Vector3 MoveTowardsEnemy(Vector3 _enemyposition, Vector3 _playerPosition)
    {
        Vector3 _baseDir = ( _enemyposition - _playerPosition).normalized;
        int _angle = UnityEngine.Random.Range(-marginOfErrorWhileAttacking / 2, marginOfErrorWhileAttacking / 2);
        return Quaternion.AngleAxis(_angle, Vector3.up) * _baseDir;
    }
    private Vector3 MoveAwayFromStadiumBoundary(Vector3 playerPosition, Transform stadiumCentre)
    {
        Vector3 _baseDir = (stadiumCentre.position - playerPosition).normalized;
        int _angle = UnityEngine.Random.Range(-fieldOfViewWhenInBoundary / 2, fieldOfViewWhenInBoundary / 2);
        return Quaternion.AngleAxis(_angle, Vector3.up) * _baseDir;
    }
    public bool IsOverlappingWithStadium(Vector3 playerPos, Transform stadiumCentre)
    {
        if ((stadiumCentre.position - playerPos).magnitude >= stadiumRadius)
        {
            return true;
        }
        return false;
    }
    

}
