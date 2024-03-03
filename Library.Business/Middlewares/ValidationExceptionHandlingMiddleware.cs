using FluentValidation;
using Library.Entities.ValidationModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Business.Middlewares
{
    public sealed class ValidationExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;


        public ValidationExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {
                var errors = exception.Errors.Select(validationFailure => new ValidationError(
                      validationFailure.PropertyName,
                      validationFailure.ErrorMessage)).ToList();

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(errors));
            }
        }
    }
}
