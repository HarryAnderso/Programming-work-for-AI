using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ToggleScoutingActionTask : ActionTask
	{
		public BBParameter<bool> scoutingBBP;
		public AudioSource audioSource;
		public AudioClip whistleSFX;
		protected override string OnExecute()
		{
			scoutingBBP.value = !scoutingBBP.value;

			Debug.Log("Toggle Scouting!");

			EndAction(true);
        }
	}
}