using System;

namespace BlockCypher.Clients.Models.Attributes;

/// <summary>
/// Indicates that this field in the request object is included in the Query String of the resource and will not be included
/// in the body
/// </summary>
public class QueryStringVariableAttribute : Attribute
{

}