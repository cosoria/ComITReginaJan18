﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ClassAttendance.Common;
using ClassAttendance.Common.Interfaces;
using ClassAttendance.Domain;

namespace ClassAttendance.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        public ApplicationUserRepository()
        {
            Init();
        }
        
        public IEnumerable<ApplicationUser> GetAll()
        {
            return _allUsers;
        }

        public IEnumerable<ApplicationUser> GetAllMatching(Predicate<ApplicationUser> condition)
        {
            return _allUsers.Where(u => condition(u)).ToArray();
        }

        public ApplicationUser GetOne(int id)
        {
            return _allUsers.FirstOrDefault(u => u.Id == id);
        }

        public void Add(ApplicationUser item)
        {
            _allUsers.Add(item);
        }

        public void Update(ApplicationUser item)
        {
            var user = GetOne(item.Id);

            if (user == null)
            {
                throw new ArgumentException("Application user not found");
            }

            user.ChangeName(item.FirstName, item.LastName);
            user.ChangePassword(item.Password);
            user.ChangeEmail(item.Email);
            user.SetLanguage(item.Language);
        }

        public void Delete(int id)
        {
            var user = GetOne(id);

            if (user == null)
            {
                throw new ArgumentException("Application user not found");
            }

            _allUsers.Remove(user);
        }

        public IEnumerable<ApplicationUser> GetLockedUsers()
        {
            return Enumerable.Empty<ApplicationUser>();
        }


        private static readonly List<ApplicationUser> _allUsers = new List<ApplicationUser>();

        private void Init()
        {
            if (_allUsers.Any())
            {
                return;
            }

            var users = new List<ApplicationUser>()
            {
                /*
                new ApplicationUser()
                {
                    Id = 0, Password = "password", FirstName = "Admin", LastName = "ComIT", Language = "English", Email = "admin@comit.com"
                },
                new ApplicationUser()
                {
                    Id = 1, Password = "password", FirstName = "Optimus", LastName = "Prime", Language = "Cybertronian", Email = "optimus@cybertron.com"
                },
                new ApplicationUser()
                {
                    Id = 2, Password = "password", FirstName = "Bumble", LastName = "Bee", Language = "Cybertronian", Email = "bumblebee@cybertron.com"
                },
                new ApplicationUser()
                {
                    Id = 3, Password = "password", FirstName = "Iron", LastName = "Hide", Language = "Cybertronian", Email = "ironhide@cybertron.com"
                },
                new ApplicationUser()
                {
                    Id = 4, Password = "password", FirstName = "Mega", LastName = "Tron", Language = "Cybertronian", Email = "megatron@cybertron.com"
                },
                new ApplicationUser()
                {
                    Id = 5, Password = "password", FirstName = "Shock", LastName = "Wave", Language = "Cybertronian", Email = "shockwave@cybertron.com",
                }
                */
            };

            _allUsers.AddRange(users);

            foreach (var user in _allUsers)
            {
                if (user.Email.StartsWith("admin"))
                {
                    user.SetRole(Constants.Roles.Admin);
                }

                if (user.Email.EndsWith("cybertron.com"))
                {
                    user.SetRole(Constants.Roles.Transformer);
                }

                user.SetRole(Constants.Roles.User);
            }
        }
    }

    
}