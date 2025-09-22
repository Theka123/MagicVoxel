using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    //복셀 공장
    public GameObject voxelFactory; 
    public int voxelPoolSize = 20;
    public static List<GameObject> voxelPool = new List<GameObject>();

    public float createTime = 0.1f;
    float currentTime = 0;

    public Transform crosshair;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++)
        {
            GameObject voxel = Instantiate(voxelFactory);

            MeshRenderer Render = voxel.GetComponent<MeshRenderer>();
            Render.material.color = Random.ColorHSV();

            voxel.SetActive(false);

            voxelPool.Add(voxel);
        }
        
    }

    // Update is called once per frame
    void Update()
    {   
        ARAVRInput.DrawCrosshair(crosshair);

        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {   
            currentTime += Time.deltaTime;
            if (currentTime > createTime)
            {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Ray ray = new Ray (ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
                RaycastHit hitInfo = new RaycastHit();

                if (Physics.Raycast(ray, out hitInfo)) 
                {
                    if (voxelPool.Count > 0 ) //오브젝트 풀 안에 복셀이 있는지 없는지 확인!           
                    {
                        GameObject voxel = voxelPool[0]; //오브젝트 풀 최상단의 값을 가져옴

                        voxel.SetActive(true);           //객체를 활성화 함

                        voxel.transform.position = hitInfo.point; //레이캐스트를 통해 얻은 충돌 지점의 위치로 객체를 이동

                        voxelPool.RemoveAt(0);           //오브젝트 풀에서 복셀 한개 제거

                        currentTime = 0;
                    }
                    
                }
            }
            
        }
    }
}
