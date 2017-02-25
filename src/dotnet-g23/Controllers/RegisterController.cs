﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Helpers;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers {
	public class RegisterController : Controller {

		#region Fields
		//private User _user;
		private readonly IUserRepository _userRepository;
		private readonly IOrganizationRepository _orgRepository;
		#endregion

		#region Constructors
		public RegisterController(UserRepository userRepository, OrganizationRepository orgRepository) {
			_userRepository = userRepository;
			_orgRepository = orgRepository;

			//_user = _userRepository.GetAll().First();
		}
		#endregion

		#region Methods
		//[Route("organizations")]
		public IActionResult Index(string query = null) {
			// return filtered list with name & location of GB organisations
			/*IEnumerable<Organization> list = _orgRepository.GetAll().Where(o => o.OrganizationRole.ToString() == "GBOrganization" );
			if (query != null)
				list = list.Where(o => (o.Name.IndexOf(query) > -1 || o.Location.IndexOf(query) > -1));*/
			return View();
		}

		//[Route("organizations/{orgname}")]
		public IActionResult Register(string orgname) {
			// validate & register user with org or throw error
            /*
			Organization org = _orgRepository.GetByName(orgname);

			if (MailHelper.VerifyMailAddress(_user.Email))
			{
				//org.Participants.Add(_user);
				return RedirectToAction("Index", "ManageController");
			}
			else {
				ViewData["Message"] = "Error: Wrong mail address";
				return View();
			}
            */
		    return View();
		}
		#endregion

	}
}
