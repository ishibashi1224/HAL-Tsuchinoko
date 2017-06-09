using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // このステートに遷移する時に一度だけ呼ばれる
    public virtual void Init() { }

    // このステートである間、毎フレーム呼ばれる
    public virtual bool Execute() { return true; }

    // このステートから他のステートに遷移するときに一度だけ呼ばれる
    public virtual void Uninit() { }
}