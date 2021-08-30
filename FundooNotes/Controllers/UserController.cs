﻿using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                bool result = this.manager.Register(userData);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "New User Added Successfull"});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "User Added Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/login")]
        public IActionResult Login([FromBody]LoginModel loginData)
        {
            try 
            {
                bool result = this.manager.Login(loginData);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Login Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login Unsuccessful" });
                }
            }
            catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}

