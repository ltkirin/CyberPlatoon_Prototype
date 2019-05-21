
using System.Collections.Generic;
/// <summary>
/// Base class for Orders, which allow Units to operate in Combat
/// </summary>
public abstract class BaseOrder
{
    #region Fields
    protected string title;
    protected OrderType type;
    #endregion

    /// <summary>
    /// Create new Order
    /// </summary>
    /// <param name="name">Order title</param>
    /// <param name="type">Order type</param>
    protected BaseOrder(string title, OrderType type)
    {
        this.title = title;
        this.type = type;
    }

    #region Properties
    /// <summary>
    /// Order title
    /// </summary>
    public string Title
    {
        get => title;
    }
    /// <summary>
    /// Order type
    /// </summary>
    public OrderType Type
    {
        get => type;
    }
    #endregion

    /// <summary>
    /// Resolve the Order
    /// </summary>
    /// <param name="orderParameters">Parameters, needed to resolve the ORder</param>
    public abstract void Execute(List<object> orderParameters);
}
