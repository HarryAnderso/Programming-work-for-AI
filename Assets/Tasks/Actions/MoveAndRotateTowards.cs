using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem.Android;


namespace NodeCanvas.Tasks.Actions {

	public class MoveAndRotateTowards : ActionTask {


		private float movespeed;
		private float turnspeed;
		public Transform target;
		public float stoppingdistance = 0.1f;

        private Blackboard agentblackboard;
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
			movespeed = agentblackboard.GetVariableValue<float>("movespeed");
            turnspeed = agentblackboard.GetVariableValue<float>("turnspeed");
			
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Vector3 direction = target.position - agent.transform.position;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, lookRotation, turnspeed*Time.deltaTime);
           
            agent.transform.position += agent.transform.forward * movespeed * Time.deltaTime;

			if(Vector3.Distance(agent.transform.position, target.position) <= stoppingdistance)
			{
				Debug.Log("Reached Target");
                EndAction(true);
            }
        }

		
	}
}