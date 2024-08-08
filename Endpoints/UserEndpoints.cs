using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Simple_C__Data_Access_with_Dapper_and_SQL.Dtos.ResponseDtos;
using Simple_C__Data_Access_with_Dapper_and_SQL.RequestModels;
using Simple_C__Data_Access_with_Dapper_and_SQL.Services.Interfaces;

namespace Simple_C__Data_Access_with_Dapper_and_SQL.Endpoints
{
    public static  class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/customer/create-customer", async (HttpContext context, [FromBody] CustomerRequestModel model,
            IValidator<CustomerRequestModel> customerRequestModelValidator,
            ICustomerService customerService) =>
            {
                await customerRequestModelValidator.ValidateAndThrowAsync(model);

                var user = await customerService.CreateCustomer(model.FirstName, model.LastName, model.Email, model.Password);
                return Results.Ok(user);
            })
        .WithTags("Customer")
        .WithDescription("Create a Customer")
        .Produces<CustomerResponseDto>()
        .Produces<ClientErrorResponseTypeDto>(400);
        }
    }
}

//endpoints.MapPost("/admin/add-user", async (HttpContext context, [FromBody] AddUserRequestModel model,
//IValidator<AddUserRequestModel> addUserRequestModelValidator,
//IAddUserService addUserService) =>
//{
//    await addUserRequestModelValidator.ValidateAndThrowAsync(model);

//    var user = await addUserService.AddUser(model.FirstName, model.LastName, model.Email, model.Password, model.RoleKey);
//    return Results.Ok(user);
//})
//.WithTags("Admin")
//.WithDescription("Add an Admin")
//.Produces<AddUserResponseDto>()
//.Produces<ClientErrorResponseTypeDto>(400);