using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Hurt : ActionTask {

		public BBParameter<GameObject> otherFSMObject;
		private Blackboard otherFSMBlackboard;

        

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

			otherFSMBlackboard = otherFSMObject.value.GetComponent<Blackboard>();

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			float temphealth = otherFSMBlackboard.GetVariableValue<float>("Health");

			otherFSMBlackboard.SetVariableValue("Health", (temphealth - 2));
			EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}