using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileBase : MonoBehaviour
{
    public float damage;
    public float speed;
    public GameObject currTarget;
    float angle;

    protected void Spin()
    {
        if (!currTarget)
            Destroy(this.gameObject);

        angle += 0.8f;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        /*Vector2 targ = currTarget.transform.position;
        Vector2 objectPos = this.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));*/
    }

    protected void GoToEnemy()
    {
        if (!currTarget)
            Destroy(this.gameObject);

        this.transform.position = Vector2.MoveTowards(this.transform.position, currTarget.transform.position, speed * Time.deltaTime);

        if (this.transform.position == currTarget.transform.position)
        {
            currTarget.GetComponent<EnemyBase>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
