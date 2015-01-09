﻿// -----------------------------------------------------------------------
// <copyright file="SecurityController.cs" company="Andrey Kurdiumov">
// Copyright (c) Andrey Kurdiumov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dub.Web.Mvc.Controllers
{
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Dub.Web.Core;
    using Dub.Web.Identity;
    using Dub.Web.Mvc.Models.Security;
    using Microsoft.AspNet.Identity.Owin;

    /// <summary>
    /// Controller for managing security related stuff.
    /// </summary>
    [Authorize(Roles = RoleNames.Administrator)]
    public class SecurityController : Controller
    {
        /// <summary>
        /// Initializes static members of the <see cref="SecurityController"/> class.
        /// </summary>
        static SecurityController()
        {
            Mapper.CreateMap<ErrorLog, ErrorLogViewModel>();
        }

        /// <summary>
        /// Display list of log entries.
        /// </summary>
        /// <returns>Return action result.</returns>
        public ActionResult Errors()
        {
            var context = this.HttpContext.GetOwinContext();
            var dbContext = context.Get<ErrorsModel>();
            return this.View(dbContext.ErrorLogs);
        }

        /// <summary>
        /// Display error log entries.
        /// </summary>
        /// <param name="id">Id of the entry to look.</param>
        /// <returns>Task which asynchronously return action result.</returns>
        public async Task<ActionResult> ErrorDetail(int id)
        {
            var context = this.HttpContext.GetOwinContext();
            var dbContext = context.Get<ErrorsModel>();
            var logEntry = await dbContext.ErrorLogs.FindAsync(id);
            var model = new ErrorLogViewModel();
            Mapper.Map(logEntry, model);
            return this.View(model);
        }
    }
}