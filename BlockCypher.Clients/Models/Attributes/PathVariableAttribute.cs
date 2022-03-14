using System;

namespace BlockCypher.Clients.Models.Attributes;

/// <summary>
/// Indicates that this field in the request object is included in the Path of the resource and will not be included
/// in the query string nor the body
/// </summary>
public class PathVariableAttribute : Attribute
{

}