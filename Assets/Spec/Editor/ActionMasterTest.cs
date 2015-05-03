using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	
	private ActionMaster actionMaster;
	
	[SetUp]
	public void Setup() {
		actionMaster = new ActionMaster();
	}
	
	[Test]
	public void FirstTossStrikeReturnsEndTurn() {
		Assert.AreEqual(endTurn, actionMaster.Bowl(10));
	}
	
	[Test]
	public void FirstTossLessThan10ReturnsTidy() {
		Assert.AreEqual(tidy, actionMaster.Bowl(9));
	}
	
	[Test]
	public void SecondTossReturnsEndTurn() {
		actionMaster.Bowl(1);
		Assert.AreEqual(endTurn, actionMaster.Bowl(1));
	}
	
}