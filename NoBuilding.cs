namespace Oxide.Plugins
{
    [Info("No Building", "Oryx", "1.0.0")]
    [Description("Only with permission can build")]

    public class NoBuilding : RustPlugin
    {
        public readonly string perm = "nobuilding.allow";

        private void Init()
        {
            permission.RegisterPermission(perm, this);
        }

        object CanBuild(Planner planner, Construction prefab, Construction.Target target)
        {
            BasePlayer player = planner.GetOwnerConnection().player as BasePlayer;

            if(player == null)
            {
                return null;
            }

            if (permission.UserHasPermission(player.UserIDString, perm))
            {
                return null;
            }

            return false;
        }
    }
}
