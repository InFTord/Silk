﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Silk.Core.Discord.Services.Interfaces;
using Silk.Shared.Abstractions.DSharpPlus.Concrete;
using Silk.Shared.Abstractions.DSharpPlus.Interfaces;

namespace Silk.Core.Discord.Commands.Server.Roles
{
    [RequireGuild]
    [Aliases("rm")]
    [Group("rolemenu")]
    [ModuleLifespan(ModuleLifespan.Transient)] // We're gonna hold some states. //
    public class RoleMenuCommand : BaseCommandModule
    {
        private record RoleMenuOption(string Name, ulong EmojiId, ulong RoleId);

        private readonly IInputService _input;
        private readonly IMessageSender _sender;
        private readonly List<IReaction> _reactions = new();

        public RoleMenuCommand(IInputService input, IMessageSender sender)
        {
            _input = input;
            _sender = sender;
        }

        [Command]
        [RequireBotPermissions(Permissions.ManageRoles)]
        public async Task Create(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            var context = new CommandExecutionContext(ctx, _sender);
            var roleMenuMessage = await _sender.SendAsync(ctx.Channel.Id, "**Awaiting setup.**");
            var setupInitializerMessage = await _sender.SendAsync(ctx.Channel.Id, "Hello! What would you like to name this role menu? " +
                                                                                  "\n(Menu will be prefixed with **Role Menu:**, title limited to 50 characters)");
            var titleMessage = string.Empty;

            while (string.IsNullOrEmpty(titleMessage))
            {
                titleMessage = await GetTitleAsync(context);
            }

            await roleMenuMessage.EditAsync($"**RoleMenu: {titleMessage}**");
            await setupInitializerMessage.DeleteAsync();

            await ConfigureRoleEmojiDictionaryAsync(roleMenuMessage, context);

        }

        private async Task ConfigureRoleEmojiDictionaryAsync(IMessage roleMenuMessage, ICommandExecutionContext context)
        {
            IMessage roleInputMessage = await context.RespondAsync(
                "Please provide the Id of a role you'd like to add. Type `done` to finish setup!\n\n" +
                "(Tip: Right-click or tap a user with the role you want to copy the Id of. Alternatively, you can find the Id in the server settings!\n" +
                "Putting a backslash (\\\\) in front of the ping will give show the Id, but mention the role! Use with caution if you're running this in a public channel.)");

            var optionsEnumerable = CreateOptionsListAsync(roleInputMessage, roleMenuMessage, context);
            if (optionsEnumerable is null)
            {
                await SendTimedOutMessageAsync(roleInputMessage, context, roleInputMessage);
                return;
            }

            var options = new List<RoleMenuOption>();

            await foreach (var rm in optionsEnumerable)
                options.Add(rm);

            // Start doing db stuff here //
        }

        private async IAsyncEnumerable<RoleMenuOption>? CreateOptionsListAsync(IMessage roleInputMessage, IMessage roleMenuMessage, ICommandExecutionContext context)
        {
            while (true)
            {
                var roleIdInputMessage = await _input.GetInputAsync(context.User.Id, context.Channel.Id, context.Guild!.Id);

                if (roleIdInputMessage is null)
                {
                    await SendTimedOutMessageAsync(roleMenuMessage, context, roleInputMessage);
                    break;
                }

                if (string.Equals(roleIdInputMessage.Content, "done", StringComparison.OrdinalIgnoreCase)) break;
                if (!ulong.TryParse(roleIdInputMessage.Content, out var id)) continue;

                if (context.Guild.Roles.Contains(id))
                {
                    await roleIdInputMessage.DeleteAsync();

                    (IEmoji? emoji, bool timedOut) emojiResult = default;

                    while (emojiResult.emoji is null)
                        emojiResult = await GetReactionAsync(context, roleInputMessage, id);

                    if (emojiResult.timedOut)
                    {
                        await SendTimedOutMessageAsync(roleMenuMessage, context, roleInputMessage);
                        break;
                    }
                    else
                    {
                        var n = new RoleMenuOption(emojiResult.emoji!.Name, emojiResult.emoji!.Id, id);

                        await roleMenuMessage.CreateReactionAsync(emojiResult.emoji);
                        await roleMenuMessage.EditAsync(roleMenuMessage.Content + $"\n{emojiResult.emoji}: <@&{id}>");
                        await Task.Delay(250);
                        await roleInputMessage.RemoveReactionsAsync();
                        await Task.Delay(250);
                        await roleInputMessage.EditAsync("Please provide the Id of a role you'd like to add. Type `done` to finish setup!");

                        yield return n;
                    }
                }
                else
                {
                    var notFoundMessage = await context.RespondAsync("That's not a role!");
                    await roleIdInputMessage.DeleteAsync();
                    await Task.Delay(3000);
                    await notFoundMessage.DeleteAsync();
                }
            }
        }

        private static async Task SendTimedOutMessageAsync(IMessage roleMenuMessage, ICommandExecutionContext context, IMessage roleInputMessage)
        {
            await roleMenuMessage.DeleteAsync();
            await roleInputMessage.DeleteAsync();
            var msg = await context.RespondAsync("Timed out!");
            await Task.Delay(3000);
            await msg.DeleteAsync();
        }

        private async Task<(IEmoji? emoji, bool timedOut)> GetReactionAsync(ICommandExecutionContext context, IMessage roleInputMessage, ulong inputResult)
        {
            await roleInputMessage.EditAsync($"Alright! React with what emoji you want to use for people to get <@&{inputResult}>?");

            var reaction = await _input.GetReactionInputAsync(context.User.Id, roleInputMessage.Id, context.Guild!.Id, TimeSpan.FromMinutes(2));

            if (reaction is null)
            {
                return (null, true);
            }
            else
            {
                if (!reaction.Emoji.IsSharedEmoji())
                {
                    var invalidEmojiMessage = await context.RespondAsync("I can't use that emoji! I don't share any servers with that emoji!");
                    await reaction.DeleteAsync();
                    await Task.Delay(3000);
                    await invalidEmojiMessage.DeleteAsync();
                    return (null, false);
                }

                return (reaction.Emoji, false);
            }
        }

        private async Task<string?> GetTitleAsync(ICommandExecutionContext ctx)
        {
            var result = await _input.GetInputAsync(ctx.User.Id, ctx.Channel.Id, ctx.Guild!.Id);
            if (string.IsNullOrEmpty(result?.Content))
            {
                return null;
            }
            else
            {
                if (result.Content.Length < 50)
                {
                    var confirmationMessage = await ctx.RespondAsync("Are you sure?");
                    var confirmationResult = await _input.GetConfirmationAsync(confirmationMessage, ctx.User.Id);

                    if (!confirmationResult ?? true)
                    {
                        await result.DeleteAsync();
                        await confirmationMessage.DeleteAsync();
                        return null;
                    }

                    await confirmationMessage.DeleteAsync();
                    await result.DeleteAsync();
                    return result.Content;
                }
                else
                {
                    var lengthExceededMessage = await ctx.RespondAsync("Sorry! But the title must not exceed 50 characters!");
                    await Task.Delay(4000);
                    await result.DeleteAsync();
                    await lengthExceededMessage.DeleteAsync();
                    return null;
                }
            }
        }
    }
}