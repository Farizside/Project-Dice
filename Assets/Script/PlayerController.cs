using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rollspeed = 3;
    private bool _isMoving;
    
    void Update()
    {
        if (_isMoving) return;

        if (Input.GetKey(KeyCode.LeftArrow)) Assemble(Vector3.left);
        if (Input.GetKey(KeyCode.RightArrow)) Assemble(Vector3.right);
        if (Input.GetKey(KeyCode.UpArrow)) Assemble(Vector3.up);
        if (Input.GetKey(KeyCode.DownArrow)) Assemble(Vector3.down);

        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir) * 1f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
        }
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;
        for (int i = 0; i < (90/_rollspeed); i++)
        {
            transform.RotateAround(anchor, axis, _rollspeed);
            yield return new WaitForSeconds(0.01f);
        }

        _isMoving = false;
    }
}
