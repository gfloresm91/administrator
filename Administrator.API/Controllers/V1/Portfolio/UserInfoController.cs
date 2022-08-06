using Administrator.API.Errors;
using Administrator.Application.Features.Portfolio.UsersInfo.Commands.CreateUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Commands.DeleteUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Commands.UpdateUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoList;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.GetUserInfoListByUsername;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.PaginationUserInfo;
using Administrator.Application.Features.Portfolio.UsersInfo.Queries.Vms;
using Administrator.Application.Features.Shared.Queries;
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
        /// <returns>List user info object</returns>
        [HttpGet(Name = "GetUsersInfo")]
        [ProducesResponseType(typeof(IEnumerable<UserInfoVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UserInfoVm>>> GetUsersInfo()
        {
            var query = new GetUserInfoListQuery();
            var usersInfo = await _mediator.Send(query);

            return Ok(usersInfo);
        }

        /// <summary>
        /// Get users info with pagination
        /// </summary>
        /// <param name="paginationUserInfoQuery">PaginationUserInfoQuery object</param>
        /// <returns>User info with relations and pagination</returns>
        [HttpGet("Pagination", Name = "GetPaginationUsersInfo")]
        [ProducesResponseType(typeof(PaginationVm<UserInfoWithIncludesVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<PaginationVm<UserInfoWithIncludesVm>>> GetPaginationUsersInfo([FromQuery] PaginationUserInfoQuery paginationUserInfoQuery)
        {
            var paginationUserInfo = await _mediator.Send(paginationUserInfoQuery);

            return Ok(paginationUserInfo);
        }

        /// <summary>
        /// Get users info by username
        /// </summary>
        /// <param name="username">User info username</param>
        /// <returns>User info object filtered by username</returns>
        [HttpGet("ByUsername/{username}", Name = "GetUsersInfoByUsername")]
        [ProducesResponseType(typeof(IEnumerable<UserInfoVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserInfoVm>>> GetUsersInfoByUsername(string username)
        {
            var query = new GetUserInfoListByUsernameQuery(username);
            var usersInfo = await _mediator.Send(query);

            return Ok(usersInfo);
        }

        /// <summary>
        /// Create user info
        /// </summary>
        /// <param name="command">CreateUserInfoCommand object</param>
        /// <returns>Return new id created</returns>
        [HttpPost(Name = "CreateUserInfo")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<int>> CreateUserInfo([FromBody] CreateUserInfoCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Update user info
        /// </summary>
        /// <param name="command">UpdateUserInfoCommand object</param>
        /// <returns>Return no content</returns>
        [HttpPut(Name = "UpdateUserInfo")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> UpdateUserInfo([FromBody] UpdateUserInfoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete user info
        /// </summary>
        /// <param name="id">User info id</param>
        /// <returns>Return ok without content</returns>
        [HttpDelete("{id}", Name = "DeleteUserInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
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
