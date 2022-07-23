using Administrator.Application.Features.Portfolio.Skills.Commands.CreateSkill;
using Administrator.Application.Features.Portfolio.Skills.Queries.GetSkillList;
using Administrator.Domain.Portfolio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Administrator.API.Controllers.Portfolio.V1
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

        /// <summary>
        /// Get skills
        /// </summary>
        /// <returns>Return skills object</returns>
        [HttpGet(Name = "GetSkills")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SkillVm>>> GetSkills()
        {
            var query = new GetSkillListQuery();
            var skills = await _mediator.Send(query);
            return Ok(skills);
        }

        /// <summary>
        /// Create skill
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Return new skill id</returns>
        [HttpPost(Name = "CreateSkill")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<int>> CreateSkill([FromBody] CreateSkillCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
