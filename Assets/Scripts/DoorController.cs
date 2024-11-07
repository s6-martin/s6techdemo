using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if (_animator.GetBool("isOpen"))
        {
            print("door open, closing");
            _animator.SetBool("isOpen", false);
        }
        else
        {
            print("door closed, opening");
            _animator.SetBool("isOpen", true);
        }
    }
}
