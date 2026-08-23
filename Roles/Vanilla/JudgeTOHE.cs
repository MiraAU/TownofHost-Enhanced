using AmongUs.GameOptions;
namespace TOHE.Roles.Vanilla;

internal class JudgeTOHE : RoleBase
{
    //===========================SETUP================================\\
    public override CustomRoles Role => CustomRoles.JudgeTOHE;
    private const int Id = 34600;
    public override CustomRoles ThisRoleBase => CustomRoles.Judge;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.CrewmateVanilla;
    //==================================================================\\

    private static OptionItem JudgeTaskRequirementPercentage;

    public override void SetupCustomOption()
    {
        Options.SetupRoleOptions(Id, TabGroup.CrewmateRoles, CustomRoles.JudgeTOHE);
        JudgeTaskRequirementPercentage = IntegerOptionItem.Create(Id + 2, GeneralOption.JudgeBase_JudgeTaskRequirementPercentage, new(0, 100, 5), 10, TabGroup.CrewmateRoles, false)
            .SetParent(Options.CustomRoleSpawnChances[CustomRoles.JudgeTOHE])
            .SetValueFormat(OptionFormat.Percent);
    }

    public override void ApplyGameOptions(IGameOptions opt, byte playerId)
    {
        AURoleOptions.ScientistCooldown = JudgeTaskRequirementPercentage.GetInt();
    }
}
