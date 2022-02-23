using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player _player;
    private PlayerMover _mover;
    private bool _shooting;

    private void Start()
    {
        _player = GetComponent<Player>();
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if(_shooting)
            _player.SpawnBullet();


        if (Input.GetKeyDown(KeyCode.W))
            _mover.MoveUp();

        if (Input.GetKeyDown(KeyCode.S))
            _mover.MoveDown();

        if (Input.GetKeyDown(KeyCode.Space))
            _shooting = true;

        if (Input.GetKeyDown(KeyCode.E))
            _player.StartInvincibleMode();

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            _mover.StopMove();

        if(Input.GetKeyUp(KeyCode.Space))
            _shooting = false;
    }
}
