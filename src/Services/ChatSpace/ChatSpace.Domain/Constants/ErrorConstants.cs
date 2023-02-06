#region Corpspace© Apache-2.0
// Copyright 2023 The Corpspace Technologies
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

namespace ChatSpace.Domain.Constants;

public static class ErrorConstants
{
    public const string ErrValidation = "error.validation";
    private const string ProblemBaseUrl = "https://www.corpspace.org/problem";
    public const string DefaultType = $"{ProblemBaseUrl}/problem-with-message";
    public static readonly string ConstraintViolationType = $"{ProblemBaseUrl}/constraint-violation";
    public static readonly string ParametrizedType = $"{ProblemBaseUrl}/parametrized";
    public static readonly string EntityNotFoundType = $"{ProblemBaseUrl}/entity-not-found";
    public static readonly string InvalidPasswordType = $"{ProblemBaseUrl}/invalid-password";
    public static readonly string EmailAlreadyUsedType = $"{ProblemBaseUrl}/email-already-used";
    public static readonly string LoginAlreadyUsedType = $"{ProblemBaseUrl}/login-already-used";
    public static readonly string EmailNotFoundType = $"{ProblemBaseUrl}/email-not-found";
}