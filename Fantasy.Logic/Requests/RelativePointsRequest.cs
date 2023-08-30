﻿using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class RelativePointsRequest
    {
        public PointAverages PointAverages { get; set; }
        public List<Player> Players { get; set; }
    }
}
