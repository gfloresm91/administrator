using Administrator.Application.Features.Portfolio.UsersInfo.Commands.CreateUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Commands.DeleteUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Commands.UpdateUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoList;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoListByUsername;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.PaginationUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms;
using Administrator.Application.Features.Shared.Queries;
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
    public class UserInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get users info
        /// </summary>
        /// <returns>User info object</returns>
        [HttpGet(Name = "GetUsersInfo")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UserInfoVm>>> GetUsersInfo()
        {
            var query = new GetUserInfoListQuery();
            var usersInfo = await _mediator.Send(query);

            return Ok(usersInfo);
        }

        [HttpGet("pagination", Name = "GetPaginationUsersInfo")]
        [Produces(typeof(PaginationVm<UserInfoWithIncludesVm>))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<PaginationVm<UserInfoWithIncludesVm>>> GetPaginationUsersInfo([FromQuery] PaginationUserInfoQuery paginationUserInfoQuery)
        {
            var paginationUserInfo = await _mediator.Send(paginationUserInfoQuery);

            return Ok(paginationUserInfo);
        }

        /// <summary>
        /// Get users info by username
        /// </summary>
        /// <param name="username">User info username</param>
        /// <returns>User info object filter by username</returns>
        [HttpGet("ByUsername/{username}", Name = "GetUsersInfoByUsername")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<IEnumerable<UserInfoVm>>> GetUsersInfoByUsername(string username)
        {
            var query = new GetUserInfoListByUsernameQuery(username);
            var usersInfo = await _mediator.Send(query);

            return Ok(usersInfo);
        }

        /// <summary>
        /// Create user info
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Return new id crated</returns>
        [HttpPost(Name = "CreateUserInfo")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<int>> CreateUserInfo([FromBody] CreateUserInfoCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Update user info
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Return no content</returns>
        [HttpPut(Name = "UpdateUserInfo")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]

        public async Task<ActionResult> UpdateUserInfo([FromBody] UpdateUserInfoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete user info
        /// </summary>
        /// <param name="id">User info id</param>
        /// <returns>Return no content</returns>
        [HttpDelete("{id}", Name = "DeleteUserInfo")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult> DeleteUserInfo(int id)
        {
            var command = new DeleteUserInfoCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
