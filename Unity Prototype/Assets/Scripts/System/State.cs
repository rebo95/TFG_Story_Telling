using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    private List<Fact> _goldFacts;  // Facts that must occur to do the story
    private List<Fact> _currentFacts;   // Facts that have ocurred
}
