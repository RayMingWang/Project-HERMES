
using UnityEngine;

public class Rope : MonoBehaviour {
	

    public Rigidbody2D first_knot;
    public GameObject knotPrefab;
	public Head headPrefab;
	public Jack jackPrefab;
	public Vector3 headSpawn= new Vector3(0,0,0);
    public int knot_count = 7;
    public float gravite_scale = 0.5f;
	public Port target;
	public PortManager manager;

	private Head head;
	private Jack jack;
	// Use this for initialization
	void Start () {
        GenerateRope();

	}

    void GenerateRope()
    {
        Rigidbody2D previousRB = first_knot;
        for(int i = 0; i < knot_count; i++)
        {
            GameObject link = Instantiate(knotPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;
            Rigidbody2D currentRB = link.GetComponent<Rigidbody2D>();
            //currentRB.gravityScale = 1 * (knot_count - 1) * (knot_count - 1) / (knot_count * knot_count* gravite_scale);
            if (i == knot_count / 2 + 1)
            {
                
                //currentRB.gravityScale = 0.1f;
            }
            else
            {
                //currentRB.gravityScale = 0.5f;
            }

            previousRB = link.GetComponent<Rigidbody2D>();
            SpriteRenderer render = link.GetComponent<SpriteRenderer>();
            
            render.sortingOrder = i + 1;

            if (i == knot_count - 1)
            {
				
				jack = Instantiate(jackPrefab,transform.parent);
				HingeJoint2D dsjoint = jack.GetComponent<HingeJoint2D>();
                dsjoint.connectedBody = previousRB;
				jack.manager = manager;
                
                //render = head.GetComponent<SpriteRenderer>();
                //render.sortingOrder = i + 2;


				//head.state = 0;
				//head.dockingPosition = headSpawn;
            }

        }
    }

	public void updateHeadState(int newstate){
		head.state = newstate;
	}

	public void freezeHead(Vector3 dockposition,Port targetport){
		target = targetport;
		head.connectPortPosition = dockposition;
		head.FreezeHead ();
		Debug.Log ("Connected port" + target.portid);
		manager.CheckLine (-1, target.portid);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
