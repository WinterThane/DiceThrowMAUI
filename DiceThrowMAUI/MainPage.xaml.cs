using DiceThrowLogic.Actors.Enemy;
using DiceThrowLogic.Actors.Player;
using DiceThrowLogic.DiceFunctions;

namespace DiceThrowMAUI;

public partial class MainPage : ContentPage
{
	public bool PlayerTurn { get; set; } = true;
	public Player MainPlayer { get; set; }
	public EnemyRat Rat { get; set; }
	public string CombatTextAll { get; set; }

	public MainPage()
	{
        InitializeComponent();
        MainPlayer = new Player("Winter", 100, 5, 10, 100);
		Rat = new EnemyRat("Normal Rat", 20, 2, 4, 10);

        CombatText.ListOfTextRows = new List<string>();
		
		BindingContext = this;
	}

	private async void PlayerThrow_Clicked(object sender, EventArgs e)
	{
        var damage = CalculateDamage.MakeDamage(MainPlayer.MinDamage, MainPlayer.MaxDamage);

        PlayerDamageLabelText.Text = $"You hit {Rat.Name} for " + damage.ToString() + " damage.";
        CombatTextAll = CombatText.CombatTextResult(PlayerDamageLabelText.Text);
		PlayerTurn = false;
		ChangeTurn();

		PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromSeconds(2));
		while (await timer.WaitForNextTickAsync())
		{
			EnemyAttack();
            timer.Dispose();
        }

        SemanticScreenReader.Announce(PlayerDamageLabelText.Text);
    }

	private void EnemyAttack()
	{
        var damage = CalculateDamage.MakeDamage(Rat.MinDamage, Rat.MaxDamage);

        EnemyDamageLabelText.Text = $"{Rat.Name} hits you for " + damage.ToString() + " damage.";
        CombatTextAll = CombatText.CombatTextResult(EnemyDamageLabelText.Text);
        PlayerTurn = true;
        ChangeTurn();

        SemanticScreenReader.Announce(EnemyDamageLabelText.Text);
    }

	private void ChangeTurn()
	{
		if (PlayerTurn)
		{
			PlayerThrowBtn.IsVisible = true;
			EnemyThrowBtn.IsVisible = false;
            PlayerDamageLabelText.IsVisible = false;
            EnemyDamageLabelText.IsVisible = true;
        }
		else
		{
			PlayerThrowBtn.IsVisible = false;
			EnemyThrowBtn.IsVisible = true;
			PlayerDamageLabelText.IsVisible = true;
            EnemyDamageLabelText.IsVisible = false;
        }

        CombatTextLabel.Text = CombatTextAll;
        SemanticScreenReader.Announce(CombatTextLabel.Text);
    }
}

