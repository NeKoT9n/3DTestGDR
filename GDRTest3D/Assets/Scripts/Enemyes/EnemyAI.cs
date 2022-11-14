using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private bool _move = false;
    private bool _atack = false;
    private Vector2 _target;

    private void Start()
    {
        if (_enemy == null)
            _enemy = GetComponent<Enemy>();
        FindPath();
        StartCoroutine(StartAI());

    }

    private void Update()
    {
        if (_move)
        {
            Vector3 position = new Vector3(_target.x, transform.position.y, _target.y);
            if (Vector3.Distance(position, transform.position) <= 0.1f)
                FindPath();
            else
                _enemy.Move(_target);
        }
        else if (_atack == true)
        {
            Atack();
        }
    }

    private void Atack()
    {
        _enemy.Atack();
        _atack = false;
    }
    private IEnumerator StartAI()
    {
        while (true)
        {
            _move = true;
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            _atack = true;
            _move = false;

            FindPath();
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void FindPath()
    {
        _target = new Vector2(transform.position.x + Random.Range(-3, 3f), transform.position.z + Random.Range(-3, 3f));
    }
}
