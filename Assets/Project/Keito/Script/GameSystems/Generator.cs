using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects  = new List<GameObject>();
    [SerializeField] private float            interval =  5.0f;
    [SerializeField] private float            height   = -9.0f;

    private bool          mCanGenerate   = true;
    private CameraHandler mCamH          = null;
    private House         mHouse         = null;

    private void Start()
    {
        mCamH = GameObject.FindWithTag("MainCamera").GetComponent<CameraHandler>();
    }

    private void Update()
    {
        if (mCanGenerate) StartCoroutine(CountGenerateInterval(interval));
    }

    IEnumerator CountGenerateInterval(float interval)
    {
        //生成
        Generate();
        //生成不可
        mCanGenerate = false;

        yield return new WaitForSeconds(interval);

        //生成可
        mCanGenerate = true;
    }

    private void Generate()
    {
        //リストからランダムに選択
        var randIdx = Random.Range(0, objects.Count);

        //スクリーン座標からランダムな生成位置を選択
        var x = Random.Range(mCamH.GetScreenRimitPos().leftBottom.x, mCamH.GetScreenRimitPos().rightTop.x - 3.0f); //-3.0fは微調整分 

        //生成座標作成
        var position = new Vector3(x, height, transform.position.z);

        var clone = Instantiate(objects[randIdx], position, Quaternion.identity);
        mHouse    = clone.GetComponent<House>();
        mHouse.AttachRigidbody();
        mHouse.Fire();
    }
}
