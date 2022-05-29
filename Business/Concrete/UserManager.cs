using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
            IUserDal _userDal;

            public UserManager(IUserDal userDal)
            {
                _userDal = userDal;
            }

            public List<OperationClaim> GetClaims(User user)
            {
                return _userDal.GetClaims(user);
            }

            public void Add(User user)
            {
                _userDal.Add(user);
            }
        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetByMail(string email)
            {
                return _userDal.Get(u => u.Email == email);
            }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
        public User GetById(int userId)
        {
            return _userDal.Get(b => b.Id == userId);
        }
    }
    }

