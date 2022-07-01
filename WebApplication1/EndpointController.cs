// Copyright (C) 2022 Canon Medical Systems Corporation. All rights reserved. Module: WebApplication1

using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1;

[ApiController]
[Route("[controller]")]
public class EndpointController : ControllerBase
{
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult> CreateAsync(
        [FromForm] [StringLength(100)] string value)
    {
        await Task.CompletedTask;
        return Ok(value);
    }
}