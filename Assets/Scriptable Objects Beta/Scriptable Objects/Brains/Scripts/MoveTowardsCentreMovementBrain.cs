using UnityEngine;

[CreateAssetMenu(fileName = "New Move Towards Centre Movement Brain ", menuName = "AI Brains / Movement Brain / Move Towards Centre")]
public class MoveTowardsCentreMovementBrain : MovementBrain
{
    [SerializeField]
    private int fieldOfViewWhenInBoundary;
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
        bool _isOverLAppingWithStadum = IsOverlappingWithStadium(_playerPos, stadiumCentre);
        if (_isOverLAppingWithStadum)
        {
            Vector3 _newMoveDir = MoveAwayFromStadiumBoundary(_playerPos, stadiumCentre);
            return _newMoveDir;
        }
        else 
        {

            return Vector3.zero;
        }
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
