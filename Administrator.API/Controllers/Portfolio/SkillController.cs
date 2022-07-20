using Administrator.Application.Features.Portfolio.Skills.Commands.CreateSkill;
using Administrator.Application.Features.Portfolio.Skills.Queries.GetSkillList;
using Administrator.Domain.Portfolio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Administrator.API.Controllers.Portfolio
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetSkills")]
        [ProducesResponseType(typeof(IEnumerable<Skill>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
            var query = new GetSkillListQuery();
            var skills = await _mediator.Send(query);
            return Ok(skills);
        }

        [HttpPost(Name = "CreateSkill")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateSkill([FromBody] CreateSkillCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
