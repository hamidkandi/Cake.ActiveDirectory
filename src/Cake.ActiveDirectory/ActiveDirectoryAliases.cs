﻿using System;
using Cake.ActiveDirectory.Users;
using Cake.Core;
using Cake.Core.Annotations;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory {
    /// <summary>
    /// Contains functionality related to managing Active Directory.
    /// </summary>
    [CakeAliasCategory("ActiveDirectory")]
    public static class ActiveDirectoryAliases {
        /// <summary>
        /// Creates a new user in the specified active directory.
        /// </summary>
        /// <example>
        /// <code>
        ///     CreateUser("cake-user", "cake-group", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net"});
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="samAccountName">The SAM account name of new user.</param>
        /// <param name="ouDistinguishedName">The distinguished name of the OU.</param>
        /// <param name="settings">The user settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("CreateUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static void AddUser(this ICakeContext context, string samAccountName, string ouDistinguishedName,
            UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            if (string.IsNullOrWhiteSpace(samAccountName)) {
                throw new ArgumentNullException(nameof(samAccountName));
            }
            if (string.IsNullOrWhiteSpace(ouDistinguishedName)) {
                throw new ArgumentNullException(nameof(ouDistinguishedName));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }
           
            var userCreate = new UserCreate(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
            userCreate.CreateUser(samAccountName, ouDistinguishedName, settings);
        }

        /// <summary>
        /// Updates a user account given the specified properties.
        /// </summary>
        /// <example>
        /// <code>
        ///     UpdateUser("employeeId", "1234", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net",
        ///         Email = "test@cake-yeah.com" });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="attributeName">The name of the attribute to search by.</param>
        /// <param name="attributeValue">The value of the attribute to search using.</param>
        /// <param name="settings">The user attribute settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("UpdateUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static void UpdateUser(this ICakeContext context, string attributeName, string attributeValue,
            UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            if (string.IsNullOrWhiteSpace(attributeName)) {
                throw new ArgumentNullException(nameof(attributeName));
            }
            if (string.IsNullOrWhiteSpace(attributeValue)) {
                throw new ArgumentNullException(nameof(attributeValue));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }

            var userUpdate = new UserUpdate(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
            userUpdate.UpdateUser(attributeName, attributeValue, settings);
        }

        /// <summary>
        /// Finds User Principal Name by Property Value.
        /// </summary>
        /// <example>
        /// <code>
        ///     var upn = FindUserByProperty("proxyAddresses", "jdoe@example.com", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net" });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="propertyName">The property name to search against.</param>
        /// <param name="propertyValue">The property value to search.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>User Principal Name</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("FindUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static string FindUserByProperty(this ICakeContext context, string propertyName, string propertyValue, UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            if (string.IsNullOrWhiteSpace(propertyName)) {
                throw new ArgumentNullException(nameof(propertyName));
            }
            if (string.IsNullOrWhiteSpace(propertyValue)) {
                throw new ArgumentNullException(nameof(propertyValue));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }
            var userFind = new UserFind(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
            return userFind.FindUserByProperty(propertyName, propertyValue);
        }
    }
}
