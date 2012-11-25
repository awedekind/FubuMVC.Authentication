﻿using System.Linq;
using FubuMVC.Authentication.Tickets;
using FubuMVC.Authentication.Tickets.Basic;
using FubuMVC.Core;
using FubuMVC.Core.Registration;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Authentication.Tests
{
    [TestFixture]
    public class AuthenticationServiceRegistryTester
    {
        private ServiceGraph theServiceGraph;

        [SetUp]
        public void SetUp()
        {
            var registry = new FubuRegistry();
            registry.Services<AuthenticationServiceRegistry>();

            theServiceGraph = BehaviorGraph.BuildFrom(registry).Services;
        }

        [Test]
        public void registers_default_IAuthenticationSession()
        {
            theDefaultServiceIs<IAuthenticationSession, TicketAuthenticationSession>();
        }

        [Test]
        public void registers_default_IPrincipalContext()
        {
            theDefaultServiceIs<IPrincipalContext, ThreadPrincipalContext>();
        }

        [Test]
        public void registers_default_ITicketSource()
        {
            theDefaultServiceIs<ITicketSource, CookieTicketSource>();
        }

        [Test]
        public void registers_default_ILoginCookieService()
        {
            theDefaultServiceIs<ILoginCookieService, LoginCookieService>();
        }

        [Test]
        public void registers_default_IEncryptor()
        {
            theDefaultServiceIs<IEncryptor, Encryptor>();
        }

        [Test]
        public void registers_default_ILoginCookies()
        {
            theDefaultServiceIs<ILoginCookies, BasicFubuLoginCookies>();
        }

        [Test]
        public void registers_default_ILoginFailureHandler()
        {
            theDefaultServiceIs<ILoginFailureHandler, NulloLoginFailureHandler>();
        }

        [Test]
        public void registers_default_IAuthenticationRedirector()
        {
            theDefaultServiceIs<IAuthenticationRedirector, AuthenticationRedirector>();
        }

        private void theDefaultServiceIs<TPlugin, TImplementation>()
        {
            theServiceGraph.DefaultServiceFor<TPlugin>()
                .Type.ShouldEqual(typeof(TImplementation));
        }
    }
}