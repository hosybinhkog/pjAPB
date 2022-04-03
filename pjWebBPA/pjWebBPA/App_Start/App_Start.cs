//// -----------------------------------------------------------------------
//// <copyright file="App_Start.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------

using Fluent.Infrastructure.FluentTools;
using pjWebBPA.DataBase;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(pjWebBPA.App_Start), "PreStart")]

namespace pjWebBPA {
    public static class App_Start {
        public static void PreStart() {
           
        }
    }
}