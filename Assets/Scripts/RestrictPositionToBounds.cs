using UnityEngine;
using System.Collections;

public class RestrictPositionToBounds : MonoBehaviour
{

    public BoxCollider2D WorldBounds;
    public BoxCollider2D ObjectBounds;

    private Vector3
        _world_min,
        _world_max,
        _object_min,
        _object_max;

    public void Start()
    {
        _world_min = WorldBounds.bounds.min;
        _world_max = WorldBounds.bounds.max;
    }

    public void FixedUpdate()
    {
        var x = transform.position.x;
        var y = transform.position.y;
		_object_min = ObjectBounds.bounds.min;
		_object_max = ObjectBounds.bounds.max;

        if (_object_min.x < _world_min.x)
        {
            x += _world_min.x - _object_min.x;
		} else if (_object_max.x > _world_max.x)
		{
			x -= _object_max.x - _world_max.x;
		}
		if (_object_min.y < _world_min.y)
		{
			y += _world_min.y - _object_min.y;
		} else if (_object_max.y > _world_max.y)
		{
			y -= _object_max.y - _world_max.y;
		}

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
