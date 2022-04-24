using UnityEngine;

[CreateAssetMenu(fileName ="New AI Run Away Action", menuName ="AI/ Actions / Run Away")]
public class AIRunAwayAction : AIAction
{
    [SerializeField]
    private int fieldOfViewWhenInBoundary,fieldOfViewWhenCloseToPlayer,fieldOfViewWhenFarFromPlayer;
    [SerializeField]
    private float thresholdDistance;
    [SerializeField]
    private float stadiumRadius = 2.32f;
    [SerializeField]
    private int playerFarCallingRate = 5;
    [SerializeField]
    private int playerNearCallingRate =1;

  
    public  override void Act(StateController _enemyStateController, StateController _playerStateController, AIController _AIController)
    {
        Vector3 _enemyPos = _enemyStateController.transform.position;
        Vector3 _playerPos = _playerStateController.transform.position;
        float _dist = (_enemyPos - _playerPos).magnitude;
        bool _isTooClose = _dist <= thresholdDistance ? true : false;
        bool _isOverLAppingWithStadum = IsOverlappingWithStadium(_AIController);
         int m_callingRate = _isTooClose || _isOverLAppingWithStadum ? playerNearCallingRate : playerFarCallingRate;
        if (_AIController.CurrentActionTime % m_callingRate != 0)
        {
            _AIController.CurrentActionTime++;
            return;
        }
        else
        {
            _AIController.CurrentActionTime = 1;
        }
        
        if (_isOverLAppingWithStadum)
        {
            Debug.Log("Overlapping with stadium");
            Vector3 _newMoveDir = MoveAwayFromStadiumBoundary( _enemyPos,_AIController.stadiumCentrePosition);
            _AIController.ChangeMoveDir(_newMoveDir);
        }
        else
        {
            
            if(_dist <= thresholdDistance)
            {
                m_callingRate = playerNearCallingRate;
                _AIController.ChangeMoveDir(MoveAwayFromEnemyWhenFar(_enemyPos, _playerPos));
            }
            else
            {
                m_callingRate = playerFarCallingRate;
            }
        }
       
    }

    private Vector3 MoveAwayFromStadiumBoundary(Vector3 _enemyPosition,Vector3 _stadiumCentre)
    {
        Vector3 _baseDir = (_stadiumCentre - _enemyPosition ).normalized;
        int _angle = UnityEngine.Random.Range(-fieldOfViewWhenInBoundary/2, fieldOfViewWhenInBoundary/2);
        return  Quaternion.AngleAxis(_angle, Vector3.up) * _baseDir;
    }
    private Vector3 MoveAwayFromEnemyWhenClose(Vector3 _enemyposition, Vector3 _playerPosition)
    {
        Vector3 _normalDir = (_playerPosition - _enemyposition).normalized;
        Vector3 _baseDir1 =  Quaternion.AngleAxis(90, Vector3.up) * _normalDir;
        Vector3 _baseDir2 =  Quaternion.AngleAxis(-90, Vector3.up) * _normalDir;
        Vector3[] _bases = new Vector3[] { _baseDir1, _baseDir2 };
        var _baseDir = _bases[UnityEngine.Random.Range(0, 2)];
        int _angle = UnityEngine.Random.Range(-fieldOfViewWhenInBoundary / 2, fieldOfViewWhenInBoundary / 2);
        return Quaternion.AngleAxis(_angle, Vector3.up) * _baseDir;
    }
    
    private Vector3 MoveAwayFromEnemyWhenFar(Vector3 _enemyposition, Vector3 _playerPosition)
    {
        Vector3 _baseDir = (_enemyposition - _playerPosition  ).normalized;
        int _angle = UnityEngine.Random.Range(-fieldOfViewWhenFarFromPlayer / 2, fieldOfViewWhenFarFromPlayer / 2);
        return Quaternion.AngleAxis(_angle, Vector3.up) * _baseDir;
    }


    public bool IsOverlappingWithStadium(AIController _AIController)
    {
        if ( (_AIController.stadiumCentrePosition - _AIController.transform.position).magnitude >= stadiumRadius)
        {
            return true;
        }
        return false;
    }
}
