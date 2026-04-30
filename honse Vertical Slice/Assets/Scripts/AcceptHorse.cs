using Unity.VisualScripting;
using UnityEngine;

//Register a string name for your Custom Scripting Event to hook it to an Event. You can save this class in a separate file and add multiple Events to it as public static strings.
public static class EventNames
{
    public static string AcceptHorse = "NewHorse";
    public static string DenyHorse = "DNewHorse";
}

[UnitTitle("OnAcceptHorse")]//The Custom Scripting Event node to receive the Event. Add "On" to the node title as an Event naming convention.
[UnitCategory("Events\\MyEvents")]//Set the path to find the node in the fuzzy finder as Events > My Events.
public class AcceptHorse : EventUnit<GameController>
{
    [DoNotSerialize]// No need to serialize ports.
    public ValueOutput result { get; private set; }// The Event output data to return when the Event is triggered.
    protected override bool register => true;

    // Add an EventHook with the name of the Event to the list of Visual Scripting Events.
    public override EventHook GetHook(GraphReference reference)
    {
        return new EventHook(EventNames.AcceptHorse);
    }

    protected override void Definition()
    {
        base.Definition();
        // Setting the value on our port.
        result = ValueOutput<GameController>(nameof(result));
    }

    // Setting the value on our port.
    protected override void AssignArguments(Flow flow, GameController data)
    {
        flow.SetValue(result, data);
    }
}

[UnitTitle("OnDenyHorse")]//The Custom Scripting Event node to receive the Event. Add "On" to the node title as an Event naming convention.
[UnitCategory("Events\\MyEvents")]//Set the path to find the node in the fuzzy finder as Events > My Events.
public class DenyHorse : EventUnit<GameController>
{
    [DoNotSerialize]// No need to serialize ports.
    public ValueOutput result { get; private set; }// The Event output data to return when the Event is triggered.
    protected override bool register => true;

    // Add an EventHook with the name of the Event to the list of Visual Scripting Events.
    public override EventHook GetHook(GraphReference reference)
    {
        return new EventHook(EventNames.DenyHorse);
    }

    protected override void Definition()
    {
        base.Definition();
        // Setting the value on our port.
        result = ValueOutput<GameController>(nameof(result));
    }

    // Setting the value on our port.
    protected override void AssignArguments(Flow flow, GameController data)
    {
        flow.SetValue(result, data);
    }
}