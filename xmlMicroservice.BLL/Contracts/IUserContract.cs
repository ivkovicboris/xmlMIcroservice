using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xmlMicroservice.BLL.Models;

namespace xmlMicroservice.BLL.Contracts
{
    public interface IUserContract
    {
        Task<bool> RegisterUser(RegisterPOCO model);
        Task<object> LoginUser(LoginPOCO loginPOCO);
    }
}
