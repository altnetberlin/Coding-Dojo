namespace Pacmans_Spike {
    public class ShellViewModel : IShell
    {
    	public ShellViewModel()
    	{
    		this.Square = new SquareViewModel();
    	}

    	public SquareViewModel Square { get; private set; }
    }
}
