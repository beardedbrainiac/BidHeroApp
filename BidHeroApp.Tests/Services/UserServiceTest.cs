using BidHeroApp.Data;
using BidHeroApp.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BidHeroApp.Models;
using BidHeroApp.Services;
using BidHeroApp.Services.Contracts;
using FakeItEasy;
using AutoMapper;
using BidHeroApp.ViewModels;
using BidHeroApp.Models.Views;
using FluentAssertions;

namespace BidHeroApp.Tests.Services
{
    public class UserServiceTest
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IUserService _service;

        public UserServiceTest()
        {
            _mapper = A.Fake<IMapper>();
            _context = GetApplicationDbContext();

            #region Service Under Test

            _service = new UserService(_mapper, _context);

            #endregion
        }

        [Fact]
        public async Task UserService_ListAsync_ReturnList()
        {
            #region Arrange

            var userViewModelList = _context.Users
                .Select(x => new UserViewModel()
                {
                    Id = Guid.Parse(x.Id),
                    Email = x.Email,
                    FamilyName = x.FamilyName,
                    GivenName = x.GivenName,
                    IsAdmin = false,
                })
                .ToList();
            if (userViewModelList != null && userViewModelList.Any())
            {
                var adminRole = _context.Roles.First(x => x.Name == "Administrator");
                if (adminRole != null)
                {
                    foreach (var userViewModel in userViewModelList)
                    {
                        userViewModel.IsAdmin = _context.UserRoles.Any(x => x.UserId == userViewModel.Id.ToString() && x.RoleId == adminRole.Id);
                    }
                }
            }
            var vmUserList = A.Fake<List<VwUser>>();
            //var userViewModelList = A.Fake<List<UserViewModel>>();
            Guid testUserId = userViewModelList.First().Id;

            #endregion

            #region Act

            var users = await _service.ListAsync();

            #endregion

            #region Assert

            users.Should().NotBeNull();
            users.Should().Contain((x) => x.Id == testUserId);
            users.Count.Should().BeGreaterThan(0);

            #endregion
        }

        private ApplicationDbContext GetApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BidHeroApp")
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();

            if ((databaseContext.Roles.Any()) == false)
            {
                var roles = new List<IdentityRole>()
                {
                    new IdentityRole()
                    {
                        Id = "3064fc34-ba70-4390-9451-b26260a1614b",
                        Name = "Owner",
                        NormalizedName = "OWNER"
                    },
                    new IdentityRole()
                    {
                        Id = "527297e4-45e3-41b3-b3a0-9b2802d5448c",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    },
                    new IdentityRole()
                    {
                        Id = "61817a28-9bf7-4dca-97b9-9044bf6cdb79",
                        Name = "User",
                        NormalizedName = "USER"
                    }
                };
                databaseContext.Roles.AddRange(roles);
                databaseContext.SaveChanges();
            }

            if ((databaseContext.Users.Any()) == false)
            {
                var users = new List<ApplicationUser>()
                {
                    new ApplicationUser()
                    {
                        Id = "8ad9f390-0767-4109-aa82-b8d55fb0d22f",
                        UserName = "cabalfinelmor17@gmail.com",
                        NormalizedUserName = "CABALFINELMOR17@GMAIL.COM",
                        Email = "cabalfinelmor17@gmail.com",
                        NormalizedEmail = "CABALFINELMOR17@GMAIL.COM",
                        EmailConfirmed = true,
                        PasswordHash = "AQAAAAIAAYagAAAAEOgAisVsjqV4QMh8wbJimztpXwApP0RsXx6v2xHROcoQao5CP6OeQjv7rbL7T4yOgQ==",
                        SecurityStamp = "C54E7OCGOC5W5AESNMS52STXG2IRFXP4",
                        ConcurrencyStamp = "8d9f5433-a019-495d-8102-fb35b2e366c4",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        GivenName = "Elmor",
                        FamilyName = "Cabalfin",
                        Gender = Gender.Male,
                        BirthDate = DateTime.Parse("1992-05-17")
                    }
                };
                databaseContext.Users.AddRange(users);
                databaseContext.SaveChanges();

                var userRoles = new List<IdentityUserRole<string>>()
                {
                    new IdentityUserRole<string>()
                    {
                        UserId = "8ad9f390-0767-4109-aa82-b8d55fb0d22f",
                        RoleId = "3064fc34-ba70-4390-9451-b26260a1614b"
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "8ad9f390-0767-4109-aa82-b8d55fb0d22f",
                        RoleId = "61817a28-9bf7-4dca-97b9-9044bf6cdb79"
                    }
                };
                databaseContext.UserRoles.AddRange(userRoles);
                databaseContext.SaveChanges();

                //foreach (var user in users)
                //{
                //    databaseContext.VwUsers.Add(new VwUser()
                //    {
                //        Id = user.Id,
                //        Email = user.Email,
                //        FamilyName = user.FamilyName,
                //        GivenName = user.GivenName,
                //        IsAdmin = userRoles.Any(x => x.UserId == user.Id && x.RoleId == "527297e4-45e3-41b3-b3a0-9b2802d5448c"),
                //    });
                //    databaseContext.SaveChanges();
                //}
            }

            return databaseContext;
        }
    }
}
