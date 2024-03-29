﻿using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using Microsoft.AspNet.Identity;
using System;

namespace AspNet.Identity.Bltoolkit
{
    /// <summary>
    /// Class that implements the ASP.NET Identity
    /// IRole interface 
    /// </summary>
    [TableName("roles")]
    public class IdentityRole : IRole
    {
        /// <summary>
        /// Default constructor for Role 
        /// </summary>
        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Constructor that takes names as argument 
        /// </summary>
        /// <param name="name"></param>
        public IdentityRole(string name) : this()
        {
            Name = name;
        }

        public IdentityRole(string name, string id)
        {
            Name = name;
            Id = id;
        }

        /// <summary>
        /// Role ID
        /// </summary>
        [MapField("id"), PrimaryKey]
        public string Id { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        [MapField("name")]
        public string Name { get; set; }
    }
}
