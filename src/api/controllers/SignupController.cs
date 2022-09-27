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
        if (!ModelState.IsValid) return BadRequest();
        if (string.IsNullOrEmpty(payload.Email) || string.IsNullOrEmpty(payload.Password) || string.IsNullOrEmpty(payload.ConfirmPassword)) return BadRequest();
        if (string.IsNullOrWhiteSpace(payload.Email) || string.IsNullOrWhiteSpace(payload.Password) || string.IsNullOrWhiteSpace(payload.ConfirmPassword)) return BadRequest();
        if (payload.Password != payload.ConfirmPassword) return BadRequest();

        var res = await _users.CreateUser(payload);
        if (res == false) return BadRequest();

        return NoContent();
    }
}