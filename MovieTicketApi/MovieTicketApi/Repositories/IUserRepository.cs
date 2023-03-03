using System;
using MovieTicketApi.Models;

namespace MovieTicketApi.Repositories
{
    public interface IUserRepository
    {
        public List<UserModel> GetAll();
        public UserModel GetById(string id);
        public void Add(UserModel user);
        public void Delete(String id);
        public UserModel GetByUsername(string name);
        public void Update(UserModel user);
    }
}

