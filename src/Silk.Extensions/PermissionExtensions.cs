﻿using System.Linq;
using DSharpPlus;
using DSharpPlus.Entities;

namespace Silk.Extensions
{
    public static class PermissionExtensions
    {
        public static bool HasPermission(this DiscordMember member, Permissions perm)
        {
            return member.Permissions.HasPermission(perm);
        }

        public static bool IsAdministrator(this DiscordMember member)
        {
            return member.Roles.Any(role => role.Permissions.HasPermission(Permissions.Administrator));
        }


        public static string GetRoleMention(this DiscordMember member)
        {
            return member.Roles.Last().Mention;
        }

        public static bool IsAbove(this DiscordMember target, DiscordMember comparison)
        {
            return target.Roles.Any() && target.Hierarchy >= comparison.Hierarchy;
        }
    }
}