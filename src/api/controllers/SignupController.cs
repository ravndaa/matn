using api.models;
using api.services;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers;


[ApiController]
[Route("api/signup")]
public class SignupController : ControllerBase
{
    private readonly IUserService _users;
    public SignupController(IUserService users)
    {
        _users = users;
    }

    [HttpPost]
    public async Task<IActionResult> PostActionAsync([FromBody] SignupUser payload)
    {
        await _users.CreateUser(payload);
        return Ok();
    }
}