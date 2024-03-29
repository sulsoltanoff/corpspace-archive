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

namespace Application.FunctionalTests.Middleware;

internal class AutoAuthorizeMiddleware
{
    private const string IdentityId = "9e3163b9-1ae6-4652-9dc6-7898ab7b7a00";

    private readonly RequestDelegate _next;


    public AutoAuthorizeMiddleware(RequestDelegate rd)
    {
        _next = rd;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var identity = new ClaimsIdentity("cookies");

        identity.AddClaim(new Claim("sub", IdentityId));
        identity.AddClaim(new Claim("unique_name", IdentityId));
        identity.AddClaim(new Claim(ClaimTypes.Name, IdentityId));

        httpContext.User.AddIdentity(identity);
        await _next.Invoke(httpContext);
    }
}
