using System.Security.Claims;
using BlogMVC.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace BlogMVC.Authorization;

// Got help from ChatGPT, unsure if this is what is meant in the task

public class OwnerRequirement : IAuthorizationRequirement {}

public class BlogOwnerHandler : AuthorizationHandler<OwnerRequirement, Blog>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OwnerRequirement requirement,
        Blog resource)
    {
        var currentUser = context.User.Identity?.Name;

        if (currentUser != null && resource.Owner?.UserName == currentUser)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
        
        return Task.CompletedTask;
    }
}