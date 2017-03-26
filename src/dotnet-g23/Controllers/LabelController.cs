﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_g23.Filters;
using dotnet_g23.Models;
using Microsoft.AspNetCore.Authorization;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using dotnet_g23.Models.ViewModels.LabelViewModels;
using dotnet_g23.Services;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_g23.Controllers {
    [Authorize(Policy = "participant")]
	[ServiceFilter(typeof(ParticipantFilter))]
    public class LabelController : Controller {
        #region Fields
        private readonly ICompanyRepository _companyRepository;
        private readonly IGroupRepository _groupRepository;
        #endregion

        #region Constructor

        public LabelController(ICompanyRepository companyRepository, IGroupRepository groupRepository) {
            _companyRepository = companyRepository;
            _groupRepository = groupRepository;
        }
        #endregion

        [Route("Companies")]
        public IActionResult Index(GUser user, String query = null) {
            // Show companies
            IndexViewModel vm = new IndexViewModel() {
                Companies = query == null ? _companyRepository.GetAll() : _companyRepository.GetByKeyword(query)
            };
            return View(vm);
        }

        [Route("Companies/{id}")]
        public IActionResult Show(Participant participant, int id) {
            
            

            // Show company contacts

            ShowViewModel vm = new ShowViewModel();
            Company company = _companyRepository.GetBy(id);
            

            Group group;
            if(participant.Group != null) {
                group = _groupRepository.GetBy(participant.Group.GroupId);
            }else if(company.Label != null) {
                group = _groupRepository.GetBy(company.Label.Group.GroupId);
            }else{
                group = null;
            }

            vm.Company = company;
            vm.Contacts = vm.Company.Contacts;
            vm.Group = group;
            vm.Motivation = group?.Motivation;
            vm.Organization = group?.Organization;
            vm.Label = company.Label;

            return View(vm);
        }

        [HttpPost]
        [Route("Companies/{id}")]
        public IActionResult Send(Participant participant, int id, int[] contactId) {
            // Grant label to company

            Company company = _companyRepository.GetBy(id);
            Group group = _groupRepository.GetBy(participant.Group.GroupId);

            try {
                group.Grant(company);
                _companyRepository.SaveChanges();


            }
            catch (GoedBezigException e) {
                TempData["error"] = e.Message;
                return RedirectToAction("Show", new { id = id });
            }
            if(group.Context.CurrentState is GrantedState){ //Grant label worked
                AuthMessageSender sender = new AuthMessageSender();

                //TODO: only has one contact atm. Multiple form submissions are the solution but I don't know how this will play out in this controller.
                foreach (var cId in contactId) { 
                    Contact contact = company.Contacts.First(co => co.ContactId == cId);
                    
                    sender.SendEmail(company.Name, contact.Email,
                        group.Organization.Name, group.Motivation.MotivationText);
                }
            }
            
            
            TempData["success"] = $"Het label werd toegekend aan de organisatie.";
            return RedirectToAction("Dashboard", "Group");
        }

    }
}
