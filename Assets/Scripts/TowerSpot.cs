using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    public List<GameObject> TurretPrefabs = new List<GameObject>();
    public GameObject Canvas;

    public float damagemod = 1, attackspeedmod = 1, rangemod = 1;

    public void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Canvas.SetActive(false);
        }
    }

    public void ChooseTurret(int i)
    {
        if (!GameManager.Instance.Pay(TurretPrefabs[i].GetComponent<TowerBase>().Price)) return;
        SoundManager.Instance.Play("Click");
        GameObject tmp = Instantiate(TurretPrefabs[i],this.transform.position,Quaternion.identity);
        tmp.GetComponent<TowerBase>().Damage *= damagemod;
        tmp.GetComponent<TowerBase>().AttackSpeed /= attackspeedmod;
        tmp.GetComponent<TowerBase>().Range *= rangemod;
        Canvas.SetActive(false);

        CardManager.Instance.TowerBaseList.Add(tmp.GetComponent<TowerBase>());
        CardManager.Instance.TowerSpotList.Remove(this);

        Destroy(Canvas);
        Destroy(this.gameObject);
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Canvas.SetActive(true);
            SoundManager.Instance.Play("Click");
        }
    }

}
