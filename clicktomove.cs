using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(LineRenderer))]
public class clicktomove : MonoBehaviour
{
	public GameManager gameManager;
	
	private Animator mAnimator;
	
	private NavMeshAgent mNavMeshAgent;
	
	public Rigidbody rb;
	
	private bool mRunning = false;

	private LineRenderer myLineRenderer;

	public GameObject Player;
	public float Distance_;
	public float maxDistance = 20f;
	public GameObject Origin;
	public float markerDist;
	public GameObject ball;
	public float distMoved;
	public int ballDistance = 1;
	public float distRemain;

	public Text availDist;
	public Text disttoTarget;
	public Text turnsReq;

	[SerializeField] private GameObject ClickMarker;
	[SerializeField] private Transform VisualObjectsParent;
	
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
		mNavMeshAgent = GetComponent<NavMeshAgent>();
		myLineRenderer = GetComponent<LineRenderer>();

		myLineRenderer.startWidth = 0.15f;
		myLineRenderer.endWidth = 0.15f;
		myLineRenderer.positionCount = 0;
	
    }
    public void Update()
    {
		int distRemainInt = Mathf.CeilToInt(distRemain);
		int markDistInt = Mathf.CeilToInt(markerDist);
		int maxDistInt = Mathf.CeilToInt(maxDistance);

		availDist.text = "Remaining This Turn: " + distRemainInt;
		disttoTarget.text = "To Reach Destination: " + markDistInt;
		turnsReq.text = "Additional Turns Required: " + (((markDistInt - distRemainInt + 20) / maxDistInt));

		mAnimator.SetBool("running", mRunning);

		Vector3 markerPos = new Vector3(ClickMarker.transform.position.x, ClickMarker.transform.position.y, ClickMarker.transform.position.z);
		Vector3 angVelocity = new Vector3(0, 0, 0);
		markerDist = Vector3.Distance(Player.transform.position, ClickMarker.transform.position);
		Distance_ = Vector3.Distance(Player.transform.position, Origin.transform.position);
		int myDistance = Convert.ToInt32(Distance_);
		distRemain = maxDistance - distMoved;
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		RaycastHit hit;

		if (Input.GetMouseButtonDown(0))
		{
			if(Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				ClickMarker.transform.SetParent(VisualObjectsParent);
				ClickMarker.transform.position = hit.point;
				ClickMarker.SetActive(true);
				mNavMeshAgent.destination = hit.point;
				mNavMeshAgent.isStopped = true;
				if (hit.transform.name == "ClickMarker")
				{
					mNavMeshAgent.isStopped = false;
					if (myDistance < maxDistance)
					{
						mRunning = true;
					}

				}
				else if (hit.transform.tag == "Unit")
				{
					mNavMeshAgent.isStopped = false;
					if (myDistance < maxDistance)
					{
						mRunning = true;
					}
				}
				
			}
		}
		if (mRunning == true)
		{
			distMoved += 10 * Time.deltaTime;
		}
		if (distMoved >= maxDistance)
		{
			mNavMeshAgent.isStopped = true;
			mRunning = false;
			rb.angularVelocity = angVelocity;
			rb.velocity = Vector3.zero;
		}

		if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance && markerDist <= 2)
		{
			if (Input.GetMouseButtonDown(0))
			{

			}
			else
			{
				ClickMarker.SetActive(false);
				mRunning = false;
			}
		}
		if (distRemain > 0 && distRemain > maxDistance)
		{
			myLineRenderer.startColor = Color.green;
			myLineRenderer.endColor = Color.red;
			/*Gradient gradient = new Gradient();
			gradient.SetKeys(
				new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) },
				new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });
			myLineRenderer.colorGradient = gradient;*/
		}
		else if (distRemain <= 0)
		{
			myLineRenderer.startColor = Color.red;
			myLineRenderer.endColor = Color.red;
		}
		
		myLineRenderer.positionCount = mNavMeshAgent.path.corners.Length;
		myLineRenderer.SetPosition(0, transform.position);

		if (mNavMeshAgent.path.corners.Length < 2)
		{
			return;
		}

		for (int i = 1; i < mNavMeshAgent.path.corners.Length; i++)
		{
			Vector3 pointPosition = new Vector3(mNavMeshAgent.path.corners[i].x, mNavMeshAgent.path.corners[i].y, mNavMeshAgent.path.corners[i].z);
			myLineRenderer.SetPosition(i, pointPosition);
			//Instantiate(ball, mNavMeshAgent.path, transform.rotation);
		}
		/*if (markerDist >= 1f && transform.position)
		{
			Instantiate(ball, myLineRenderer.transform.position, transform.rotation);
		}*/

		
	}
	 
}
