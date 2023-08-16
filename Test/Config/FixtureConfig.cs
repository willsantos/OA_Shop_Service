using AutoFixture;

namespace Test.Config
{
    public static class FixtureConfig
    {
        public static Fixture GetFixture()
        {
            Fixture fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        }
    }
}
