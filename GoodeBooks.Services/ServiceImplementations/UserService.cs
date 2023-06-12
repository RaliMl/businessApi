using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts;
using GoodeBooks.Services.ViewModels.Users;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceImplementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BookstoreDbContext context;
        private readonly IMapper mapper;

        public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, BookstoreDbContext bookstoreDbContext,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.context = bookstoreDbContext;
            this.mapper = mapper;
        }

        public bool AssignBookshelf(UserBookshelfIdsViewModel model)
        {
            try
            {
                var user = context.Users.FirstOrDefault(x => x.Id == model.UserId);
                var bookshelf = context.Bookshelves.FirstOrDefault(x => x.Id == model.BookshelfId);
                user.Bookshelves.Add(bookshelf);
                user.ModifiedAt = DateTime.Now;

                context.Users.Update(user);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<int> Create(UserCreateViewModel model)
        {
            try
            {
                var user = mapper.Map<User>(model);
                //var bookshelfIds = model.BookshelvesIds.Split(',').ToList();
                //user.Bookshelves = context.Bookshelves.Where(x => bookshelfIds.Contains(x.Id.ToString())).ToList();
                user.CreatedAt = DateTime.Now;
                user.ModifiedAt = DateTime.Now;
                var hashedPassword = userManager.PasswordHasher.HashPassword(user, model.Password);
                user.PasswordHash = hashedPassword;
                user.NormalizedEmail = model.Email.ToUpper(); 
                user.UserName = model.Email;
                user.NormalizedUserName = model.Email.ToUpper();
                

                context.Users.Add(user);

                context.SaveChanges();

                await userManager.AddToRoleAsync(user, "User");

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public bool GiveRole(string roleName)
        {

            try
            {
                var userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var roleId = context.Roles.FirstOrDefault(x => x.Name == "User").Id;

                context.UserRoles.Add(new IdentityUserRole<string> { UserId = userId, RoleId = roleId });

                return true;
            }
            catch (Exception ex) { return false; }
        }

        public int Delete(string id)
        {
            try
            {
                var user = context.Users.FirstOrDefault(e => e.Id == id);

                var bookshelves = context.Bookshelves.Where(x => user.Bookshelves.Select(x => x.Id).Contains(x.Id)).ToList();

                foreach (var bookshelf in bookshelves)
                {
                    context.Bookshelves.Remove(bookshelf);
                }
                
                context.Users.Remove(user);

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }
        public UserViewModel GetById(string id)
        {
            try
            {
                var user = context.Users.FirstOrDefault(x => x.Id == id);

                var res = mapper.Map<UserViewModel>(user);
                res.BookshelvesNames = string.Join(",", user.Bookshelves.Select(x => x.Title).ToList());

                return res;
            }
            catch (Exception e) { throw new Exception("Not found!"); }
        }

        public int Update(UserViewModel model)
        {
            try
            {
                var user = context.Users.FirstOrDefault(x => x.Id == model.Id);

                if (user != null)
                {
                    user.Name = model.Name;
                    user.ModifiedAt = DateTime.Now;
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.NormalizedEmail = model.Email.ToUpper();
                    user.NormalizedUserName = model.Email.ToUpper();
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);

                    context.Users.Update(user);

                    context.SaveChanges();

                    return 1;
                }
                return -1;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
