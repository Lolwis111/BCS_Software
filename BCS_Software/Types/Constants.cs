namespace BCS_Software.Types
{
    internal static class Constants
    {
        internal const int SoldierPoints = 4;
        internal const int TankPoints = 11;
        internal const int JetPoints = 33;

        internal const float SoldierOnSoldier = 1.0f;
        internal const float SoldierOnTank = 0.25f;
        internal const float SoldierOnJet = 0.5f;

        internal const float TankOnSoldier = 2.0f;
        internal const float TankOnTank = 1.0f;
        internal const float TankOnJet = 1.0f;

        internal const float JetOnSoldier = 3.0f;
        internal const float JetOnTank = 1.5f;
        internal const float JetOnJet = 1.0f;
    }
}
