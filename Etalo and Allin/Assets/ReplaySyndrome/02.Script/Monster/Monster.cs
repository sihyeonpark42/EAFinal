using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class Monster : MonoBehaviour
{
    PhotonView PV;
    protected NavMeshAgent agent;
    protected float hp = 50f;
    protected int positionNum = 10;
    protected Vector3[] movePositions;
    protected float moveDistance = 50;
    protected int currPositionPivot = 0;
    protected float speed = 0;
    protected Animator animator;
    protected GameObject[] player;
    protected float attackTime = 0;
    protected bool isDead = false;
    public int playerCount = 0;
    protected float attactDistance = 7f;
    protected int selectedPlayerIndex = 0;


    //Animator Parameter
    protected string paraDie = "Die";
    protected string paraIdle = "Idle";
    protected string paraAttack = "Attack";
    protected string paraMove = "Move";
    AnimatorStateInfo currAnimatorStateInfo;


    protected virtual void Awake()
    {
        PV = GetComponent<PhotonView>();
        speed = 5;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        movePositions = new Vector3[positionNum];
        animator = GetComponent<Animator>();
        makePath();
        player = GameObject.FindGameObjectsWithTag("Player");
        hp = 300f;
        playerCount = player.Length;
        StartCoroutine("FindPlayerAndSetDest");
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        currAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (hp <= 0 && isDead == false)
        {
            isDead = true;
            agent.speed = 0;
            animator.SetTrigger(paraDie);

            int obj_ID = gameObject.GetComponent<PhotonView>().ViewID;
            print(obj_ID);
            
            //Destroy(gameObject, 5.0f);
            PV.RPC("DestroyRPC", RpcTarget.AllBuffered, obj_ID);
            StopCoroutine("FindPlayerAndSetDest");
        }
    }

    protected Vector3 GetRandomPosOnNavmesh(Vector3 center, float distance)
    {
        Vector3 randomPos;

        NavMeshHit navMeshHit;
        while (true)
        {
            randomPos = Random.insideUnitSphere * distance + center;
            if (NavMesh.SamplePosition(randomPos, out navMeshHit, distance, NavMesh.AllAreas))
            {
                break;
            }
        }
        return navMeshHit.position;
    }

    protected void makePath()
    {
        for (int i = 0; i < positionNum; ++i)
        {
            movePositions[i] = GetRandomPosOnNavmesh(transform.position, moveDistance);
        }
    }

    protected void MoveToPosition()
    {
        if (player.Length > 0)
        {
            for (int i = 0; i < player.Length; ++i)
            {
                if (Vector3.Distance(player[i].GetComponent<Transform>().position, transform.position) < attactDistance )
                {
                    agent.speed = 0;
                }



                if (Vector3.Distance(player[i].GetComponent<Transform>().position, transform.position) < attactDistance)
                {

                    if ((currAnimatorStateInfo.IsName(paraMove)))
                    {
                        animator.SetTrigger(paraAttack);
                        selectedPlayerIndex = i;
                        attackTime = Time.time;
                        agent.speed = 0;       
                    }
                    else
                    {

                        return;
                    }
                    
                }
                else if (Vector3.Distance(player[i].GetComponent<Transform>().position, transform.position) < 30)
                {
                    agent.SetDestination(player[i].GetComponent<Transform>().position);
                    agent.speed = speed;
                }
                else
                {
                    agent.SetDestination(movePositions[currPositionPivot]);
                    agent.speed = speed;
                }
            }
        }
        else
        {
            agent.SetDestination(movePositions[currPositionPivot]);
            agent.speed = speed;
        }

       

        if (Vector3.Distance(movePositions[currPositionPivot], transform.position) < 0.5)
        {
            currPositionPivot = ++currPositionPivot % positionNum;
            if(currPositionPivot % 3 == 0)
            {
                animator.SetTrigger(paraIdle);
            }
        }

        
        if(currAnimatorStateInfo.IsName(paraMove))
        {
            agent.speed = speed;
        }
        else
        {
            agent.speed = 0;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < movePositions.Length; ++i)
        {
            Gizmos.DrawSphere(movePositions[i], 1);
        }

        Gizmos.color = Color.red;
        Gizmos.color = new Color(1, 0, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, 30);
    }


    IEnumerator FindPlayerAndSetDest()
    {

        while (true)
        {

            MoveToPosition();


            player = GameObject.FindGameObjectsWithTag("Player");
            playerCount = player.Length;

            yield return new WaitForSeconds(0.1f);

        }
    }

    void SetAnimatorIdle()
    {
        animator.SetTrigger(paraIdle);
    }

    void AttackPlayer()
    {
        player[selectedPlayerIndex].GetComponent<EtaloController>().DamagedFromMonster(2f);
        print("AttackToPlayer");
    }

    public void Damaged(float damage)
    {
        hp -= damage;
        print("몬스터 데미지" + damage.ToString());
    }

    [PunRPC]
    private void DestroyRPC(int obj_ID)
    {
        Destroy(PhotonView.Find(obj_ID).gameObject);
        
    }
    
}
