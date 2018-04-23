using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.Characters.ThirdPerson { 
    public class WalkAround : MonoBehaviour {

        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Vector3 target;                                    // target to aim for

        public  GameObject[] WayPoints;


        int mIndex = 0;

	    // Use this for initialization
	    void Start () {
            WayPoints = GameObject.FindGameObjectsWithTag("Waypoint");

            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;       //Character does it owmn rotation
            agent.updatePosition = true;
            target = WayPoints[mIndex].transform.position;
        }


        // Update is called once per frame
        void Update() {
            Vector3 tDistance = WayPoints[mIndex].transform.position- transform.position;
            tDistance.y = 0;

            if (tDistance.magnitude>1.0f) {     //Check for arrival
                character.Move(tDistance, false, false);
            } else {
                mIndex++;
                if (mIndex >= WayPoints.Length) mIndex = 0;
                target = WayPoints[mIndex].transform.position;
            }
        }
    }
}