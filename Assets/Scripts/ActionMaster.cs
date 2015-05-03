using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action { Tidy, Reset, EndTurn, EndGame }
	
	private int[] bowls = new int[21];
	private int bowl = 1;
	
	public Action Bowl(int pins) {
		if (pins < 0 || pins > 10) { throw new UnityException("Invalid pin count detected."); }
	
		// Strike!
		if (pins == 10) { return Action.EndTurn; }
		
		if (bowl % 2 != 0) {
			bowl++;
			return Action.Tidy; 
		} else {
			bowl = 1;
			return Action.EndTurn;
		}
		
		throw new UnityException("Not sure what action to return! smh");
	}
}
