using Administrator.API.Errors;
using Administrator.Application.Features.Portfolio.Skills.Commands.CreateSkill;
using Administrator.Application.Features.Portfolio.Skills.Queries.GetSkillList;
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
        /// <returns>Return list of skills object</returns>
        [HttpGet(Name = "GetSkills")]
        [ProducesResponseType(typeof(IEnumerable<SkillVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
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
        /// <param name="command">CreateSkillCommand object</param>
        /// <returns>Return new skill id</returns>
        [HttpPost(Name = "CreateSkill")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<int>> CreateSkill([FromBody] CreateSkillCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
