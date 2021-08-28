using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccese;
using Common.Cache;

namespace Domain
{
    public class UserModel
    {
        UserDao userDao = new UserDao();

        private int idUser;
        private string LoginName;
        private string password;
        private string fisrtName;
        private string LastName;
        private string position;
        private string email;

        public UserModel(int idUser, string LoginName, string password, string firstName, string LastName, string position, string email)
        {
            this.idUser = idUser;
            this.LoginName = LoginName;
            this.password = password;
            this.fisrtName = firstName;
            this.LastName = LastName;
            this.position = position;
            this.email = email;
        }

        public UserModel() { }

        public string editUserPorfile()
        {
            
            try
            {
                userDao.editPorfile(idUser, LoginName, password, fisrtName, LastName, email);
                LoginUser(LoginName, password);
                return "Your porfile as been successfully update";
            }
            catch (Exception ex)
            {
               return "Username is already registered, try another";
            }
        }


        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

        public string recoverPassword(string userRequesting)
        {
            return userDao.recoveryPassword(userRequesting);
        }

        
    }
}
