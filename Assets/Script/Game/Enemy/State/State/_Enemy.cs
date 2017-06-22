using UnityEngine;
using System.Collections;

namespace StateMachineSample
{
    public enum _EnemyState
    {
        Wander,
        Pursuit,
        Attack,
        Explode,
    }

    //public class _Enemy : StatefulObjectBase<_Enemy, _EnemyState>
    //{
    //    public Transform turret;
    //    public Transform muzzle;
    //    public GameObject bulletPrefab;

    //    private Transform player;

    //    private int maxLife = 3;
    //    private int life;

    //    private float speed = 10f;
    //    private float rotationSmooth = 1f;
    //    private float turretRotationSmooth = 0.8f;
    //    private float attackInterval = 2f;

    //    private float pursuitSqrDistance = 2500f;
    //    private float attackSqrDistance = 900f;
    //    private float margin = 50f;

    //    private float changeTargetSqrDistance = 40f;

    //    private void Start()
    //    {
    //        Initialize();
    //    }

    //    public void Initialize()
    //    {
    //        // 始めにプレイヤーの位置を取得できるようにする
    //        player = GameObject.FindWithTag("Player").transform;

    //        life = maxLife;

    //        // ステートマシンの初期設定
    //        stateList.Add(new StateWander(this));
    //        stateList.Add(new StatePursuit(this));
    //        stateList.Add(new StateAttack(this));
    //        stateList.Add(new StateExplode(this));

    //        stateMachine = new StateMachine<_Enemy>();

    //        ChangeState(_EnemyState.Wander);
    //    }

    //    public void TakeDamage()
    //    {
    //        life--;
    //        if (life <= 0)
    //        {
    //            ChangeState(_EnemyState.Explode);
    //        }
    //    }

    //    #region States

    //    /// <summary>
    //    /// ステート: 徘徊
    //    /// </summary>
    //    private class StateWander : State<_Enemy>
    //    {
    //        private Vector3 targetPosition;

    //        public StateWander(_Enemy owner) : base(owner) {}

    //        public override void Enter()
    //        {
    //            // 始めの目標地点を設定する
    //            targetPosition = GetRandomPositionOnLevel();
    //        }

    //        public override void Execute()
    //        {
    //            // プレイヤーとの距離が小さければ、追跡ステートに遷移
    //            float sqrDistanceToPlayer = Vector3.SqrMagnitude(owner.transform.position - owner.player.position);
    //            if (sqrDistanceToPlayer <  owner.pursuitSqrDistance - owner.margin)
    //            { 
    //                owner.ChangeState(_EnemyState.Pursuit);
    //            }

    //            // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
    //            float sqrDistanceToTarget = Vector3.SqrMagnitude(owner.transform.position - targetPosition);
    //            if (sqrDistanceToTarget < owner.changeTargetSqrDistance)
    //            {
    //                targetPosition = GetRandomPositionOnLevel();
    //            }

    //            // 目標地点の方向を向く
    //            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - owner.transform.position);
    //            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.rotationSmooth);

    //            // 前方に進む
    //            owner.transform.Translate(Vector3.forward * owner.speed * Time.deltaTime);
    //        }

    //        public override void Exit() {}

    //        public Vector3 GetRandomPositionOnLevel()
    //        {
    //            float levelSize = 55f;
    //            return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    //        }
    //    }

    //    /// <summary>
    //    /// ステート: 追跡
    //    /// </summary>
    //    private class StatePursuit : State<_Enemy>
    //    {
    //        public StatePursuit(_Enemy owner) : base(owner) {}

    //        public override void Enter() {}

    //        public override void Execute()
    //        {
    //            // プレイヤーとの距離が小さければ、攻撃ステートに遷移
    //            float sqrDistanceToPlayer = Vector3.SqrMagnitude(owner.transform.position - owner.player.position);
    //            if (sqrDistanceToPlayer < owner.attackSqrDistance - owner.margin)
    //            { 
    //                owner.ChangeState(_EnemyState.Attack);
    //            }

    //            // プレイヤーとの距離が大きければ、徘徊ステートに遷移
    //            if (sqrDistanceToPlayer > owner.pursuitSqrDistance + owner.margin)
    //            { 
    //                owner.ChangeState(_EnemyState.Wander);
    //            }

    //            // プレイヤーの方向を向く
    //            Quaternion targetRotation = Quaternion.LookRotation(owner.player.position - owner.transform.position);
    //            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.rotationSmooth);

    //            // 前方に進む
    //            owner.transform.Translate(Vector3.forward * owner.speed * Time.deltaTime);
    //        }

    //        public override void Exit() {}
    //    }

    //    /// <summary>
    //    /// ステート: 攻撃
    //    /// </summary>
    //    private class StateAttack : State<_Enemy>
    //    {
    //        private float lastAttackTime;

    //        public StateAttack(_Enemy owner) : base(owner) { }

    //        public override void Enter() {}

    //        public override void Execute()
    //        {
    //            // プレイヤーとの距離が大きければ、追跡ステートに遷移
    //            float sqrDistanceToPlayer = Vector3.SqrMagnitude(owner.transform.position - owner.player.position);
    //            if (sqrDistanceToPlayer > owner.attackSqrDistance + owner.margin)
    //            { 
    //                owner.ChangeState(_EnemyState.Pursuit);
    //            }

    //            // 砲台をプレイヤーの方向に向ける
    //            Quaternion targetRotation = Quaternion.LookRotation(owner.player.position - owner.turret.position);
    //            owner.turret.rotation = Quaternion.Slerp(owner.turret.rotation, targetRotation, Time.deltaTime * owner.turretRotationSmooth);

    //            // 一定間隔で弾丸を発射する
    //            if (Time.time > lastAttackTime + owner.attackInterval)
    //            {
    //                Instantiate(owner.bulletPrefab, owner.muzzle.position, owner.muzzle.rotation);
    //                lastAttackTime = Time.time;
    //            }
    //        }

    //        public override void Exit() {}
    //    }

    //    /// <summary>
    //    /// ステート: 爆発
    //    /// </summary>
    //    private class StateExplode : State<_Enemy>
    //    {
    //        public StateExplode(_Enemy owner) : base(owner) {}

    //        public override void Enter()
    //        {
    //            // ランダムな吹き飛ぶ力を加える
    //            Vector3 force = Vector3.up * 1000f + Random.insideUnitSphere * 300f;
    //            owner.GetComponent<Rigidbody>().AddForce(force);

    //            // ランダムに吹き飛ぶ回転力を加える
    //            Vector3 torque = new Vector3(Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
    //            owner.GetComponent<Rigidbody>().AddTorque(torque);

    //            // 1秒後に自身を消去する
    //            Destroy(owner.gameObject, 1.0f);
    //        }

    //        public override void Execute() {}

    //        public override void Exit() {}
    //    }

    //    #endregion

    //}
}
