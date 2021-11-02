using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slicer : MonoBehaviour
{
    public Material material;
    public LayerMask layerMask;
    public GameObject newParent;


    public void OnDrawGizmos()
    {
        EzySlice.Plane cuttingPlane = new EzySlice.Plane();

        cuttingPlane.Compute(transform);

        cuttingPlane.OnDebugDraw();
    }
    private void Update()
    {
        

        
            Collider[] kesilecekNesneler = Physics.OverlapBox(transform.position, new Vector3(1f, 0.1f, 1f), transform.rotation, layerMask);

            foreach (Collider nesne in kesilecekNesneler)
            {
                SlicedHull kesilecekNesne = Kes(nesne.gameObject, material);
                GameObject kesilmisUst = kesilecekNesne.CreateUpperHull(nesne.gameObject, material);
                GameObject kesilmisAlt = kesilecekNesne.CreateLowerHull(nesne.gameObject, material);

                BilesenEkle(kesilmisUst);
                BilesenEkle(kesilmisAlt);

                Destroy(nesne.gameObject);
            }
        }
    
   


    public SlicedHull Kes(GameObject obj, Material mat = null)
    {
        return obj.Slice(transform.position, transform.up, mat); 
    }

    void BilesenEkle(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        obj.GetComponent<Rigidbody>().AddExplosionForce(200, obj.transform.position, 20);
    }
}
