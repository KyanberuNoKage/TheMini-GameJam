using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastUtilScript : MonoBehaviour
{

    [Header("Debug Ray Lines:")]

    public bool ShowDebugRayLines = false;
    public bool ShowDebugIn_Range = false;
    public bool ShowDebugIn_Range_Circle = false;




    //InRange//

    ///<summary>
    ///Creates A Ray Using Given Vector2 Position, Vector2 Direction And The Distance The Ray Will Travel.
    ///This Ray Is Blue.
    ///</summary>
    ///<returns>
    ///This Method Returns A Bool Value.
    ///</returns>
    #region InRange Overload 1
    public bool InRange(Vector2 position, Vector2 direction, float distance)
    {
        RaycastHit2D ray = Physics2D.Raycast(position, direction, distance);

        if (ShowDebugRayLines || ShowDebugIn_Range)
        {
            Debug.DrawRay(position, direction * distance, Color.green);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    ///<summary>
    ///Use This Overload When Creating A Ray On Only One Specific Layer.
    ///</summary>
    ///<returns>
    ///This Method Returns A Bool Value.
    ///</returns>
    #region InRange Overload 2
    public bool InRange(Vector2 position, Vector2 direction, float distance, LayerMask mask)
    {
        RaycastHit2D ray = Physics2D.Raycast(position, direction, distance, mask);

        if (ShowDebugRayLines || ShowDebugIn_Range)
        {
            Debug.DrawRay(position, direction * distance, Color.green);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    ///<summary>
    ///Checks wether a name or a tag needs to be checked for.
    ///If Name_Or_Tag is "name", the name will be checked, if "tag", the tag will be checked.
    ///If any other string is given the method will return false.
    ///</summary>
    ///<returns>
    ///This Method Returns A Bool Value.
    ///</returns>
    #region InRange Overload 3
    public bool InRange(Vector2 position, Vector2 direction, float distance, LayerMask mask, string colliderNameOrTag, string Name_Or_Tag)
    {
        RaycastHit2D ray = Physics2D.Raycast(position, direction, distance, mask);

        if (ShowDebugRayLines || ShowDebugIn_Range)
        {
            Debug.DrawRay(position, direction * distance, Color.green);
        }

        /*Check wether a name or a tag needs to be checked for.
        If Name_Or_Tag is "name", the name will be checked, if "tag", the tag will be checked.
        If any other string is given the method will return false.*/
        switch (Name_Or_Tag)
        {
            case "name":
                if (ray.collider != null)
                {
                    if (ray.collider.name == colliderNameOrTag)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            case "tag":
                if (ray.collider != null)
                {
                    if (ray.collider.CompareTag(colliderNameOrTag))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            default:
                return false;
        }


    }
    #endregion

    //InRange - GameObject Ref Overloads//

    ///<summary>
    ///Same as Overload 1, but with the GameObject Ref.
    ///</returns>
    #region InRange Overload 4
    public bool InRange(Vector2 position, Vector2 direction, float distance, ref GameObject ObjectHit)
    {
        RaycastHit2D ray = Physics2D.Raycast(position, direction, distance);

        if (ShowDebugRayLines || ShowDebugIn_Range)
        {
            Debug.DrawRay(position, direction * distance, Color.green);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                ObjectHit = ray.collider.gameObject;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    ///<summary>
    ///Same as Overload 2, but with the GameObject Ref.
    ///</returns>
    #region InRange Overload 5
    public bool InRange(Vector2 position, Vector2 direction, float distance, LayerMask mask, ref GameObject ObjectHit)
    {
        RaycastHit2D ray = Physics2D.Raycast(position, direction, distance, mask);

        if (ShowDebugRayLines || ShowDebugIn_Range)
        {
            Debug.DrawRay(position, direction * distance, Color.green);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                ObjectHit = ray.collider.gameObject;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    ///<summary>
    ///Same as Overload 3, but with the GameObject Ref.
    ///</returns>
    #region InRange Overload 6
    public bool InRange(Vector2 position, Vector2 direction, float distance, LayerMask mask, string colliderNameOrTag, string Name_Or_Tag, ref GameObject ObjectHit)
    {
        RaycastHit2D ray = Physics2D.Raycast(position, direction, distance, mask);

        if (ShowDebugRayLines || ShowDebugIn_Range)
        {
            Debug.DrawRay(position, direction * distance, Color.green);
        }

        /*Check wether a name or a tag needs to be checked for.
        If Name_Or_Tag is 1, the name will be checked, if 0, the tag will be checked.
        If an int value above 1 or below 0 is given the method will return false.*/
        switch (Name_Or_Tag)
        {
            case "name":
                if (ray.collider != null)
                {
                    if (ray.collider.name == colliderNameOrTag)
                    {
                        ObjectHit = ray.collider.gameObject;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            case "tag":
                if (ray.collider != null)
                {
                    if (ray.collider.CompareTag(colliderNameOrTag))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            default:
                return false;
        }
    }
    #endregion




    //InRangeCircle//

    ///<summary>
    ///Creates A Ray Using Given Vector2 Position, Vector2 Direction, 
    ///this ray will stay in the position it is offset to.
    ///This ray will center around the given position, and be twice as long as t.
    ///This Ray Is Red.
    ///</summary>
    #region InRangeCircle Overload 1
    public bool InRangeCircle(Vector2 position, float offset, Vector2 direction, float distance)
    {

        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction, distance * 2);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region InRangeCircle Overload 2
    public bool InRangeCircle(Vector2 position, float offset_x, float offset_y, Vector2 direction, float distance)
    {

        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(offset_x, offset_y) + new Vector2(distance, 0f), direction, distance * 2);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(offset_x, offset_y) + new Vector2(distance, 0f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region InRangeCircle Overload 3
    public bool InRangeCircle(Vector2 position, float offset, Vector2 direction, float distance, LayerMask mask)
    {
        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction, distance * 2, mask);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region InRangeCircle Overload 4
    public bool InRangeCircle(Vector2 position, float offset, Vector2 direction, float distance, LayerMask mask, string colliderNameCheck)
    {
        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction, distance * 2, mask);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == colliderNameCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    ///<summary>
    ///Use This Ray When No Offset Is Needed.
    ///</summary>
    #region InRangeCircle Overload 5
    public bool InRangeCircle(Vector2 position, float distance, Vector2 direction)
    {

        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(distance, 0) + new Vector2(0f, 0.5f), direction, distance * 2);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(distance, 0) + new Vector2(0f, 0.5f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
    #endregion

    //InRangeCircle - GameObject Ref Overloads//

    ///<summary>
    ///This Method Returns The Bool "True" If Its Ray Hits
    ///A GameObject, And Sets A Refrenced GameObject Var To
    ///The GameObject The Ray Has Hit.
    /// </summary>

    ///<summary>
    ///Same as Overload 1, but with the GameObject Ref
    ///</returns>
    #region InRangeCircle Overload 6
    public bool InRangeCircle(Vector2 position, float offset, Vector2 direction, float distance, ref GameObject ObjectHit)
    {

        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction, distance * 2);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                ObjectHit = ray.collider.gameObject;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    ///<summary>
    ///Same as Overload 2, but with the GameObject Ref
    ///</returns>
    #region InRangeCircle Overload 7
    public bool InRangeCircle(Vector2 position, float offset_x, float offset_y, Vector2 direction, float distance, ref GameObject ObjectHit)
    {

        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(offset_x, offset_y) + new Vector2(distance, 0f), direction, distance * 2);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(offset_x, offset_y) + new Vector2(distance, 0f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                ObjectHit = ray.collider.gameObject;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    ///<summary>
    ///Same as Overload 3, but with the GameObject Ref
    ///</returns>
    #region InRangeCircle Overload 8
    public bool InRangeCircle(Vector2 position, float offset, Vector2 direction, float distance, LayerMask mask, ref GameObject ObjectHit)
    {
        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction, distance * 2, mask);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                ObjectHit = ray.collider.gameObject;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    ///<summary>
    ///Same as Overload 4, but with the GameObject Ref
    ///</returns>
    #region InRangeCircle Overload 9
    public bool InRangeCircle(Vector2 position, float offset, Vector2 direction, float distance, LayerMask mask, string colliderNameCheck, ref GameObject ObjectHit)
    {
        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction, distance * 2, mask);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(offset, 0) + new Vector2(distance, 0f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == colliderNameCheck)
            {
                ObjectHit = ray.collider.gameObject;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    ///<summary>
    ///Same as Overload 5, but with the GameObject Ref
    ///</returns>
    ///<summary>
    ///Use This Ray When No Offset Is Needed.
    ///</summary>
    #region InRangeCircle Overload 10
    public bool InRangeCircle(Vector2 position, float distance, Vector2 direction, ref GameObject ObjectHit)
    {

        RaycastHit2D ray = Physics2D.Raycast(position + new Vector2(distance, 0) + new Vector2(0f, 0.5f), direction, distance * 2);

        if (ShowDebugRayLines || ShowDebugIn_Range_Circle)
        {
            Debug.DrawRay(position + new Vector2(distance, 0) + new Vector2(0f, 0.5f), direction * distance * 2, Color.red);
        }

        if (ray.collider != null)
        {
            if (ray.collider.name == "player")
            {
                ObjectHit = ray.collider.gameObject;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
    #endregion

}
