﻿using Utm.Builder.Core.ValueObjects;

namespace Utm.Builder.Core;

public class Utm
{
    public Utm(Url url, Campaign campaign)
    {
        Url = url;
        Campaign = campaign;
    }

    /// <summary>
    /// URL (Website Link)
    /// </summary>
    public Url Url { get; set; }

    /// <summary>
    /// Campaign Details
    /// </summary>
    public Campaign Campaign { get; set; } 
}
