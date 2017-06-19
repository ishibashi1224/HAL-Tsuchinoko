using UnityEngine;

public class State : MonoBehaviour
{
    // このステートに遷移する時に一度だけ呼ばれる
    public virtual void Init() {}

    // このステートである間、毎フレーム呼ばれる
    public virtual void Update() {}

    // このステートから他のステートに遷移するときに一度だけ呼ばれる
    public virtual void Uninit() {}
}
