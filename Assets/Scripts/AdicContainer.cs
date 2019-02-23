using Adic;
using Assets.Scripts.Rooms;
using Assets.Scripts.Rooms.Interfaces;

namespace Assets.Scripts
{
    public class AdicContainer : ContextRoot {

        public override void SetupContainers()
        {
            this.AddContainer<InjectionContainer>()
                .Bind<IRoom>().To<BaseRoom>();
        }

        public override void Init()
        {
            // On game startup.
        }
    }
}
