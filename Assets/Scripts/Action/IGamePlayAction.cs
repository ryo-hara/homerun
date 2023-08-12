using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGamePlayAction
{
    public abstract class ArgumentBase { }
    
    
    IEnumerator Execute();
    
    void Prepare();

    void Disable();

}
