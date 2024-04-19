using AutoMapper;
using Isopoh.Cryptography.Argon2;
using LibraryAPI.DTO.Book;
using LibraryAPI.DTO.User;
using LibraryAPI.Enums;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[Route("/api/user")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var user = await _userRepository.GetListAsync();
        return Ok(user);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto data)
    {
        var hashPassword = Argon2.Hash(data.Password);
        if (hashPassword == null)
        {
            return StatusCode(500);
        }
        var user = await _userRepository.Create(new UserEntity
        {
            Username = data.Username,
            Password = hashPassword,
            Role = data.Role
        });
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdateUserDto data)
    {
        var userData = _mapper.Map<UserEntity>(data);
        var user = await _userRepository.UpdateByIdAsync(id, userData);
        return Ok(user);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> SoftDeleteById([FromRoute] Guid id)
    {
        var user = await _userRepository.SoftDeleteByIdAsync(id);
        return Ok(user);
    }
}