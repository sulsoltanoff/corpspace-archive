﻿#region Corpspace© Apache-2.0
// Copyright © 2023 Sultan Soltanov. All rights reserved.
// Author: Sultan Soltanov
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

namespace Corpspace.Services.Webhooks.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class WebhooksController : ControllerBase
{
    private readonly WebhooksContext _dbContext;
    private readonly IIdentityService _identityService;
    private readonly IGrantUrlTesterService _grantUrlTester;

    public WebhooksController(WebhooksContext dbContext, IIdentityService identityService, IGrantUrlTesterService grantUrlTester)
    {
        _dbContext = dbContext;
        _identityService = identityService;
        _grantUrlTester = grantUrlTester;
    }

    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WebhookSubscription>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ListByUser()
    {
        var userId = _identityService.GetUserIdentity();
        var data = await _dbContext.Subscriptions.Where(s => s.UserId == userId).ToListAsync();
        return Ok(data);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(WebhookSubscription), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetByUserAndId(int id)
    {
        var userId = _identityService.GetUserIdentity();
        var subscription = await _dbContext.Subscriptions.SingleOrDefaultAsync(s => s.Id == id && s.UserId == userId);
        if (subscription != null)
        {
            return Ok(subscription);
        }
        return NotFound($"Subscriptions {id} not found");
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(418)]
    public async Task<IActionResult> SubscribeWebhook(WebhookSubscriptionRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var grantOk = await _grantUrlTester.TestGrantUrl(request.Url, request.GrantUrl, request.Token ?? string.Empty);

        if (grantOk)
        {
            var subscription = new WebhookSubscription()
            {
                Date = DateTime.UtcNow,
                DestUrl = request.Url,
                Token = request.Token,
                Type = Enum.Parse<WebhookType>(request.Event, ignoreCase: true),
                UserId = _identityService.GetUserIdentity()
            };

            _dbContext.Add(subscription);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetByUserAndId", new { id = subscription.Id }, subscription);
        }
        else
        {
            return StatusCode(418, "Grant url can't be validated");
        }
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UnsubscribeWebhook(int id)
    {
        var userId = _identityService.GetUserIdentity();
        var subscription = await _dbContext.Subscriptions.SingleOrDefaultAsync(s => s.Id == id && s.UserId == userId);

        if (subscription != null)
        {
            _dbContext.Remove(subscription);
            await _dbContext.SaveChangesAsync();
            return Accepted();
        }

        return NotFound($"Subscriptions {id} not found");
    }

}
