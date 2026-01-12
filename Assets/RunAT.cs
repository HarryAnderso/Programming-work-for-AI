using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace NodeCanvas.Tasks.Actions {

	public class RunAT : ActionTask {

        private Blackboard agentblackboard;

        public float movespeed;
		public Vector3 direction;
        public float stoppingdistance = 0.01f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            agentblackboard = agent.GetComponent<Blackboard>();
            if (agentblackboard != null)
            {
                return null;
            }
            else return "No Blackboard Found on Agent";
        }

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			direction.x = Random.Range((agent.transform.position.x-5f), (agent.transform.position.x + 5f));
            direction.z = Random.Range((agent.transform.position.z - 5f), (agent.transform.position.z + 5f));
            //EndAction(true);

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            
			agent.transform.position = Vector3.MoveTowards(agent.transform.position, direction, movespeed * Time.deltaTime);


            if (Vector3.Distance(agent.transform.position, direction) <= stoppingdistance)
            {
				agentblackboard.SetVariableValue("cubepos", agent.transform.position);
				agentblackboard.SetVariableValue("cuberot", agent.transform.eulerAngles);
                Debug.Log("Reached Target");
                agentblackboard.SetVariableValue("done", true);
                EndAction(true);
            }

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}