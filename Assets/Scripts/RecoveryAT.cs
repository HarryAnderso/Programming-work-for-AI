using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RecoveryAT : ActionTask {

        //public BBParameter<GameObject> otherFSMObject;
       //private Blackboard otherFSMBlackboard;

		private Blackboard agentBlackboard;
		//public BBParameter<float> recHealth;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            //otherFSMBlackboard = otherFSMObject.value.GetComponent<Blackboard>();
			agentBlackboard = agent.GetComponent<Blackboard>();
			

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            

            
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            //float temphealth = otherFSMBlackboard.GetVariableValue<float>("Health");
            //float recHealth = agentBlackboard.GetVariableValue<float>("RecoveryHealth");
			float temphealth = 0;
            if (agentBlackboard.GetVariableValue<float>("RecoveryHealth") <= 10)
			{
				//otherFSMBlackboard.SetVariableValue("Health", (temphealth + Time.deltaTime));
				agentBlackboard.SetVariableValue("RecoveryHealth", temphealth += agentBlackboard.GetVariableValue<float>("RecoveryHealth") + Time.deltaTime);
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