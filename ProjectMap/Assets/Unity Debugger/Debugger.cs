using UnityEngine;
using System.Collections;

public class Debugger : MonoBehaviour
{
	static public void Log(string _msg, string _id, bool _addLocation = false)
	{
		if(!HasID(_id)) return;

		print(_msg);
	}

	static private bool HasID(string id)
	{
		return System.Array.IndexOf(DebugSettings.interests, id) > -1;
	}
}