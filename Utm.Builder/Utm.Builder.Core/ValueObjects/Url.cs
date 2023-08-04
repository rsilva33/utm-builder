<<<<<<< HEAD
﻿using System.Text;
using System.Text.RegularExpressions;
=======
﻿using System.Text.RegularExpressions;
>>>>>>> 0a22806f5e46b2731b7db91ddb01fdaa4f35dbbe
using Utm.Builder.Core.ValueObjects.Exceptions;

namespace Utm.Builder.Core.ValueObjects;


public class Url : ValueObject
{

    /// <summary>
    /// Create a new URL
    /// </summary>
    /// <param name="address">Address of URL (Website link)</param>
    public Url(string address)
    {
        Address = address;
<<<<<<< HEAD
        InvalidUrlException.ThrowIfInvalid(address);
=======
        InvalidUrlException.ThrowIfInvalidUrl(address);
>>>>>>> 0a22806f5e46b2731b7db91ddb01fdaa4f35dbbe
    }

    /// <summary>
    /// Address of URL (Website link)
    /// </summary>

    public string Address { get; }
}
