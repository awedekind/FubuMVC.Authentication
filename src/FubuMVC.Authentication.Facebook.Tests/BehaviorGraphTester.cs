using FubuCore;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Authentication.Facebook.Tests
{
    [TestFixture]
    public class BehaviorGraphTester
    {
        [Test]
        public void chain_contains_an_object_def()
        {
            var graph = BehaviorGraph.BuildFrom(registry =>
                {
                    registry.Import<ApplyAuthentication>();
                    registry.Import<ApplyFacebookAuthentication>();
                });

            var chain = graph.BehaviorFor<FacebookController>(x => x.Button(null));
            var def = chain.As<IContainerModel>().ToObjectDef();

            def.ShouldNotBeNull();
        }
    }
}