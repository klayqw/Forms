﻿using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Steam.Core.Dto;
using Steam.Core.Interfaces;
using Steam.Core.ViewModel;
using System.Security.Claims;

namespace Steam.Controllers;

public class GroupController : Controller
{
    private readonly IGroupServices groupService;
    private readonly IValidator<GroupDto> validator;
    public GroupController(IGroupServices groupService, IValidator<GroupDto> validator)
    {
        this.groupService = groupService;
        this.validator = validator;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Chat(int id)
    {
        var message = await groupService.GetAllMesageFromChat(id);
        return View(new MessageViewModel()
        {
            creator = groupService.GetById(id).Result.Creator,
            messages = message,
            Groupid = id
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Message([FromBody]MessageDto message)
    {
        Console.WriteLine(message.Message);
        message.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        await groupService.AddMessage(message);
        return RedirectToAction("Chat",message.GroupId);
    }

    [HttpDelete]
    [Authorize]

    public async Task<IActionResult> MessageDelete(int id)
    {
        try
        {
            await groupService.DeleteMessage(id, User.Identity.Name);
        }catch(Exception ex)
        {
            return RedirectToAction(actionName: "Error", controllerName: "ErrorPage", new { message = ex.Message });
        }
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await groupService.GetAll();
            return View(result);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await groupService.GetById(id);
            var users = await groupService.GetUsersInGroup(id);

            var usergroups = await groupService.ShowJoinedGroup(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            return View(new GroupViewModel()
            {
                Group = result,
                Users = users,
                UserGroup = usergroups
            });
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

    [HttpGet]
    [Authorize]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(GroupDto dto)
    {
        try
        {
            var result = validator.Validate(dto);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(
                        key: error.PropertyName,
                        errorMessage: error.ErrorMessage
                    );
                }
                return View("Add");
            }
            await groupService.Add(dto, User.Identity.Name);
            return RedirectToAction("GetAll");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserGroup()
    {
        try
        {
            var result = await groupService.GetUserGroup(User.Identity.Name);
            return View(result);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> JoinIn(int id)
    {
        try
        {
            Console.WriteLine(id);
            await groupService.JoinInGroup(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return RedirectToAction("ShowJoinedGroup");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ShowJoinedGroup()
    {
        try
        {
            var result = await groupService.ShowJoinedGroup(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return View(result);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Leave(int id)
    {
        try
        {
            await groupService.Leave(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return RedirectToAction("ShowJoinedGroup");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        try
        {
            await groupService.Delete(id, HttpContext);
            return RedirectToAction("GetAll");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Update(int id)
    {
        try
        {
            var toedit = await groupService.GetById(id);
            return View(toedit);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] GroupDto dto)
    {
        try
        {
            var result = validator.Validate(dto);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(
                        key: error.PropertyName,
                        errorMessage: error.ErrorMessage
                    );
                }
                return View("Update");
            }
            await groupService.Update(dto, id, HttpContext);
            return RedirectToAction("GetAll");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "ErrorPage", new { message = ex.Message });
        }
    }

}
