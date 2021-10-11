﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.Models;
using IdentityServer4.EntityFramework.Mappers;

namespace Identity.Administration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityResourceController : ControllerBase
    {
        private readonly ConfigurationDbContext _configurationDbContext;
        public IdentityResourceController(ConfigurationDbContext configurationDbContext)
        {
            _configurationDbContext = configurationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _configurationDbContext.IdentityResources.FindAsync(id);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await _configurationDbContext.IdentityResources.FindAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }

            var result = _configurationDbContext.IdentityResources.Remove(entity);
            await _configurationDbContext.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Create([FromBody] IdentityResource model)
        {
            var result = _configurationDbContext.IdentityResources.Add(model.ToEntity());
            await _configurationDbContext.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] IdentityResource model)
        {
            var result = _configurationDbContext.IdentityResources.Update(model.ToEntity());
            await _configurationDbContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}
