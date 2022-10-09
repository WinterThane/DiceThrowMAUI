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
		InitiatePlayer();
		InitiateEnemy();

        CombatText.ListOfTextRows = new List<string>();
		
		BindingContext = this;
	}

	private void InitiatePlayer()
	{
        MainPlayer = new Player("Winter", 100, 100, 5, 10, "playerwarrior.png");
        PlayerFrame.BackgroundColor = new Color(50, 50, 50, 255);
        PlayerDetailsLabel.Text = StringFunctions.MakePlayerDetails(MainPlayer);       
    }

	private void InitiateEnemy()
	{
        Rat = new EnemyRat("Giant Rat", 20, 2, 4, 10, "enemyrat.png");
    }

	private async void PlayerThrow_Clicked(object sender, EventArgs e)
	{
        var damage = CalculateDamage.MakeDamage(MainPlayer.MinDamage, MainPlayer.MaxDamage);

        PlayerDamageLabelText.Text = $"You hit {Rat.Name} for " + damage.ToString() + " damage.";
        CombatTextAll = CombatText.CombatTextResult(PlayerDamageLabelText.Text);
		PlayerTurn = false;
		ChangeTurn();

		PeriodicTimer timer = new(TimeSpan.FromSeconds(Config.ENEMY_TURN));
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
            PlayerDamageLabelText.IsVisible = false;
            EnemyDamageLabelText.IsVisible = true;
			PlayerFrame.BackgroundColor = new Color(50, 50, 50, 255);
            EnemyFrame.BackgroundColor = new Color(0, 0, 0, 255);
        }
		else
		{
			PlayerThrowBtn.IsVisible = false;
			PlayerDamageLabelText.IsVisible = true;            
			EnemyDamageLabelText.IsVisible = false;
            EnemyFrame.BackgroundColor = new Color(50, 50, 50, 255);
            PlayerFrame.BackgroundColor = new Color(0, 0, 0, 255);
        }

        CombatTextLabel.Text = CombatTextAll;
        SemanticScreenReader.Announce(CombatTextLabel.Text);
    }

	private void ClearCombatTextBtn_Clicked(object sender, EventArgs e)
	{
		CombatText.CleanCombatText();
		CombatTextAll = string.Empty;
        CombatTextLabel.Text = CombatTextAll;
        SemanticScreenReader.Announce(CombatTextLabel.Text);
    }
}

