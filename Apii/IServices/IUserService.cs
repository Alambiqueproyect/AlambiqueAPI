﻿using Entities.Entities;

namespace API.IServices
{
    public interface IUserService
    {
        int InsertUser(UserItem userItem);
        void DeleteUser(int Id);
        void UpdateUser(UserItem userItem);
        List<UserItem> GetUserByCriteria(int Id);
        List<UserItem> GetAll();
    }
}