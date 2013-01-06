// Guids.cs
// MUST match guids.h
using System;

namespace StevenRobbins.KillCassini
{
    static class GuidList
    {
        public const string guidKillCassiniPkgString = "61aa765b-1320-403a-948a-62eebd5df6f7";
        public const string guidKillCassiniCmdSetString = "aa05d614-4421-41f5-85e4-8de23128b62b";

        public static readonly Guid guidKillCassiniCmdSet = new Guid(guidKillCassiniCmdSetString);
    };
}