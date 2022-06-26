using Microsoft.EntityFrameworkCore;
using Messanger.Server.DataBase;
using Messanger.Server.DataBase.Models;
namespace Messanger.Server.Controllers;

public static class UserEndpoints
{
    public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/User", async (DataBaseContext db) =>
        {
            return await db.Users.ToListAsync();
        })
        .WithName("GetAllUsers")
        .Produces<List<User>>(StatusCodes.Status200OK);

        routes.MapGet("/api/User/{id}", async (int Id, DataBaseContext db) =>
        {
            return await db.Users.FindAsync(Id)
                is User model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetUserById")
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/User/{id}", async (int Id, User user, DataBaseContext db) =>
        {
            var foundModel = await db.Users.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            foundModel.Password = user.Password;
            foundModel.CreatedAt = DateTime.Now;

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateUser")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/User/", async (User user, DataBaseContext db) =>
        {
            var checkLogin = await db.Users.FirstOrDefaultAsync(u => u.Login == user.Login);

            if (checkLogin != null)
            {
                return Results.Accepted($"/Users/{user.Id}", checkLogin);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Results.Created($"/Users/{user.Id}", user);
        });

        routes.MapDelete("/api/User/{id}", async (int Id, DataBaseContext db) =>
        {
            if (await db.Users.FindAsync(Id) is User user)
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return Results.Ok(user);
            }

            return Results.NotFound();
        })
        .WithName("DeleteUser")
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
