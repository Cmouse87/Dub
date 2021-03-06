﻿// -----------------------------------------------------------------------
// <copyright file="UsersListViewModel.cs" company="Andrey Kurdiumov">
// Copyright (c) Andrey Kurdiumov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dub.Web.Mvc.Models.User
{
    using System.Linq;
    using Dub.Web.Identity;

    /// <summary>
    /// View model for the user lists.
    /// </summary>
    public class UsersListViewModel
    {
        /// <summary>
        /// Gets or sets users.
        /// </summary>
        public IQueryable<DubUser> Users { get; set; }
    }
}
