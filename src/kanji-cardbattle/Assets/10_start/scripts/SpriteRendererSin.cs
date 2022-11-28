using UnityEngine;

public class SpriteRendererSin : MonoBehaviour
{
    // 点滅させる対象
    [SerializeField] private SpriteRenderer _target;

    // 点滅周期[s]
    [SerializeField] private float _cycle = 1;

    private float _time;

    private void Update()
    {
        // 内部時刻を経過させる
        _time += Time.deltaTime;
        
        // 周期cycleで繰り返す波のアルファ値計算
        var alpha = Mathf.Cos(2 * Mathf.PI * _time / _cycle) * 0.25f + 0.75f;

        // 内部時刻timeにおけるアルファ値を反映
        var color = _target.color;
        color.a = alpha;
        _target.color = color;
    }
}